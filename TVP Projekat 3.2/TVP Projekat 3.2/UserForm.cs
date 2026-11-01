using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace TVP_Projekat_3._2
{
 public partial class UserForm:Form
 {
  private readonly Korisnik trenutniKorisnik;
  private bool settingDates;
  public UserForm(Korisnik user){InitializeComponent();trenutniKorisnik=user;DostupneCheckBox.CheckedChanged+=(s,e)=>RenderOffers();}
  private void UserForm_Load(object sender,EventArgs e){Funkcije.ucitajSve();RefreshViews(true);}
  private void RefreshViews(bool dates=false)
  {
   FillCities(GradoviRezervacija,Funkcije.PronadjiListuRezervacija(trenutniKorisnik.KorisnikId).Select(r=>Funkcije.PronadjiDestinaciju(r).Mesto));
   FillCities(GradoviDestinacija,Funkcije.dest.Select(d=>d.Mesto));
   if(dates){settingDates=true;var trips=Funkcije.dest;var start=trips.Count==0?DateTime.Today:trips.Min(d=>d.DatumOd);var end=trips.Count==0?DateTime.Today.AddYears(1):trips.Max(d=>d.DatumDo);DatumDoRezervacije.Value=end;DatumOdRezervacije.Value=start;DatumDoDestinacije.Value=end;DatumOdDestinacije.Value=start;settingDates=false;}
   RenderReservations();RenderOffers();
  }
  private void FillCities(ComboBox cb,IEnumerable<string> cities){string selected=cb.SelectedItem as string;cb.Items.Clear();cb.Items.Add("Svi gradovi");foreach(var c in cities.Distinct().OrderBy(x=>x))cb.Items.Add(c);cb.SelectedIndex=selected!=null&&cb.Items.Contains(selected)?cb.Items.IndexOf(selected):0;}
  private bool CityMatches(ComboBox cb,Destinacija d){return cb.SelectedIndex<=0||(string)cb.SelectedItem==d.Mesto;}
  public static bool IsDateInRange(DateTime date,DateTime start,DateTime end){return date.Date>=start.Date&&date.Date<=end.Date;}
  private GroupBox Card(Destinacija d,string extra,int y){var box=new GroupBox{Text=d.Drzava+" / "+d.Mesto,Location=new Point(0,y),Size=new Size(364,159)};box.Controls.Add(new Label{Text=d.DatumOd.ToShortDateString()+" - "+d.DatumDo.ToShortDateString()+Environment.NewLine+extra,Location=new Point(12,24),Size=new Size(338,90)});return box;}
  private void ClearPanel(Panel p){while(p.Controls.Count>0)p.Controls[0].Dispose();}
  private void RenderReservations()
  {
   ClearPanel(panel2);int y=0;
   foreach(var r in Funkcije.PronadjiListuRezervacija(trenutniKorisnik.KorisnikId)){
    var d=Funkcije.PronadjiDestinaciju(r);if(d==null||(!IstorijaCheckBox.Checked&&Funkcije.RezervacijaProsla(r))||!CityMatches(GradoviRezervacija,d)||!IsDateInRange(d.DatumOd,DatumOdRezervacije.Value,DatumDoRezervacije.Value))continue;
    var box=Card(d,"Broj osoba: "+r.BrojRezervisanihMesta+Environment.NewLine+"Ukupna cena: "+r.UkupnaCena,y);y+=165;
    var edit=new Button{Text="Izmeni",Location=new Point(190,122),Enabled=d.DatumOd.Date>=DateTime.Today};edit.Click+=(s,e)=>EditReservation(r);
    var cancel=new Button{Text="Otkazi",Location=new Point(275,122),Enabled=d.DatumOd.Date>=DateTime.Today};cancel.Click+=(s,e)=>{if(MessageBox.Show("Otkazati rezervaciju?","Potvrda",MessageBoxButtons.YesNo)==DialogResult.Yes)Run(()=>{Funkcije.CancelReservation(r.RezervacijaId);RefreshViews();});};
    box.Controls.Add(edit);box.Controls.Add(cancel);panel2.Controls.Add(box);
   }
   if(y==0)panel2.Controls.Add(new Label{Text="Nema rezervacija za izabrane filtere.",AutoSize=true});
  }
  private void RenderOffers()
  {
   ClearPanel(panel3);int y=0;Funkcije.PrebrojRezervisano();
   foreach(var d in Funkcije.dest){int available=Math.Max(0,d.UkupnoMesta-d.Rezervisanih);if(d.DatumOd.Date<DateTime.Today||!CityMatches(GradoviDestinacija,d)||!IsDateInRange(d.DatumOd,DatumOdDestinacije.Value,DatumDoDestinacije.Value)||(DostupneCheckBox.Checked&&available==0))continue;
    var box=Card(d,"Cena po osobi: "+Funkcije.Price(d,1)+Environment.NewLine+"Slobodna mesta: "+available,y);y+=165;
    var n=new NumericUpDown{Minimum=0,Maximum=available,Location=new Point(170,122),Width=65};
    var price=new Label{Text="Ukupno: 0",Location=new Point(10,125),Width=150};
    var book=new Button{Text="Rezervisi",Location=new Point(250,122),Enabled=false};
    n.ValueChanged+=(s,e)=>{price.Text="Ukupno: "+Funkcije.Price(d,(int)n.Value);book.Enabled=n.Value>0;};
    book.Click+=(s,e)=>Run(()=>{Funkcije.SaveReservation(trenutniKorisnik.KorisnikId,d.DestinacijaId,(int)n.Value);RefreshViews();});
    box.Controls.Add(n);box.Controls.Add(price);box.Controls.Add(book);panel3.Controls.Add(box);
   }
   if(y==0)panel3.Controls.Add(new Label{Text="Nema ponuda za izabrane filtere.",AutoSize=true});
  }
  private void EditReservation(Rezervacija r)
  {
   var d=Funkcije.PronadjiDestinaciju(r);using(var dialog=new Form{Text="Izmena broja osoba",ClientSize=new Size(300,140),StartPosition=FormStartPosition.CenterParent,FormBorderStyle=FormBorderStyle.FixedDialog,MaximizeBox=false,MinimizeBox=false}){
    var seats=new NumericUpDown{Minimum=1,Maximum=d.UkupnoMesta-d.Rezervisanih+r.BrojRezervisanihMesta,Value=r.BrojRezervisanihMesta,Location=new Point(20,30)};
    var price=new Label{Location=new Point(20,70),AutoSize=true,Text="Cena: "+Funkcije.Price(d,(int)seats.Value)};seats.ValueChanged+=(s,e)=>price.Text="Cena: "+Funkcije.Price(d,(int)seats.Value);
    var save=new Button{Text="Sacuvaj",Location=new Point(190,100)};save.Click+=(s,e)=>{try{Funkcije.SaveReservation(r.KorisnikId,r.DestinacijaId,(int)seats.Value,r.RezervacijaId);dialog.DialogResult=DialogResult.OK;}catch(Exception ex){MessageBox.Show(ex.Message);}};
    dialog.Controls.Add(seats);dialog.Controls.Add(price);dialog.Controls.Add(save);if(dialog.ShowDialog(this)==DialogResult.OK)RefreshViews();
   }
  }
  private void Run(Action action){try{action();}catch(Exception ex){MessageBox.Show(ex.Message,"Operacija nije zavrsena");}}
  private void RezervacijeSearchButton_Click(object sender,EventArgs e){RenderReservations();}
  private void DestinacijeSearchButton_Click(object sender,EventArgs e){RenderOffers();}
  private void IstorijaCheckBox_CheckedChanged(object sender,EventArgs e){RenderReservations();}
  private void dateTimePicker1_ValueChanged(object sender,EventArgs e){if(!settingDates&&DatumOdRezervacije.Value>DatumDoRezervacije.Value)DatumDoRezervacije.Value=DatumOdRezervacije.Value;}
  private void dateTimePicker2_ValueChanged(object sender,EventArgs e){if(!settingDates&&DatumDoRezervacije.Value<DatumOdRezervacije.Value)DatumOdRezervacije.Value=DatumDoRezervacije.Value;}
 }
}
