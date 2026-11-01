using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TVP_Projekat_3._2
{
    public partial class AdminForm : Form
    {

        List<TextBox> textBoxLista;
        Button lastBtn;
        bool izmena = false;
        public AdminForm()
        {
            InitializeComponent();
            textBoxLista = new List<TextBox>();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Funkcije.ucitajSve();
            
            PopuniKorisnike();
            PopuniDestinacije();
            DatumOdPicker.MinDate = DateTime.Now;
            DatumOdPicker.MaxDate = DateTime.Now.AddYears(10);
            //listaTkRezervacije = Funkcije.PronadjiListuRezervacija(trenutniKorisnik.KorisnikId);
            
        }

//
//GENERISANJE UI
//

        private void PopuniKorisnike()
        {
            panel1.Controls.Clear();
            int pomeraj = 0;

            foreach (Korisnik user in Funkcije.users)
            {
                GroupBox g = new GroupBox();
                g.Size = new Size(364, 159);
                g.Location = new Point(0, 0 + pomeraj);
                //g.Bo
                pomeraj += 160;

                PictureBox p = new PictureBox();
                p.Image = TVP_Projekat_3._2.Properties.Resources.user;
                p.Location = new Point(7, 19);
                p.Size = new Size(100, 100);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                g.Controls.Add(p);

                TextBox t = new TextBox();
                t.Multiline = true;

                t.Text = "KorisnikID: " + user.KorisnikId + Environment.NewLine + "Ime i prezime: " +
                    user.Ime + " " + user.Prezime + Environment.NewLine + "Username: " + user.Username +
                    Environment.NewLine +
                    "IsAdmin: " + user.IsAdmin;

                t.Location = new Point(114, 19);
                t.BackColor = SystemColors.Control;
                t.BorderStyle = BorderStyle.None;
                t.Size = new Size(244, 100);
                t.ReadOnly = true;
                g.Controls.Add(t);

                /*Label l = new Label();
                l.Location = new Point(111, 130);
                l.Size = new Size(120, 13);
                l.Name = "UkupnaCenaLabel";
                l.Text = "Ukupna cena: 0";
                g.Controls.Add(l);*/

                /*Button b = new Button();
                b.Location = new Point(201, 125);
                b.Size = new Size(75, 23);
                b.Name = user.KorisnikId.ToString();
                b.Text = "Izmeni";
                b.Enabled = false; // Edit reservations through the user account.
                g.Controls.Add(b);

                b = new Button();
                b.Location = new Point(121, 125);
                b.Size = new Size(75, 23);
                b.Name = user.KorisnikId.ToString();
                b.Text = "Vise info";
                b.Click += MoreInfo_Click; ;
                g.Controls.Add(b);*/

                Button b = new Button();
                b.Location = new Point(282, 125);
                b.Size = new Size(75, 23);
                b.Name = user.KorisnikId.ToString();
                b.Text = "Vise info";
                b.Click += MoreInfo_Click;
                g.Controls.Add(b);

                panel1.Controls.Add(g);
            }
        }
        private void MoreInfo_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Korisnik k = Funkcije.PronadjiKorisnika(Int32.Parse(btn.Name));
            foreach (Control c in UserTabPage.Controls)
            {
                if (c.Name == "InfoPanel")
                {
                    UserTabPage.Controls.Remove(c);
                }
            }
            //btn.Parent.BackColor = Color.LightBlue;
            MoreInfo(k);
        }
        private void MoreInfo(Korisnik user)
        {
            Panel p = new Panel();
            p.Size = new Size(388, 424);
            p.BackColor = SystemColors.Control;
            p.Name = "InfoPanel";
            p.Location = new Point(0, 0);

            GroupBox g = new GroupBox();
            g.Size = new Size(388, 159);
            g.Location = new Point(0, 0);
            //g.Bo


            PictureBox img = new PictureBox();
            img.Image = TVP_Projekat_3._2.Properties.Resources.user;
            img.Location = new Point(7, 19);
            img.Size = new Size(100, 100);
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            g.Controls.Add(img);

            TextBox t = new TextBox();
            t.Multiline = true;

            t.Text = "KorisnikID: " + user.KorisnikId + Environment.NewLine + "Ime i prezime: " +
                user.Ime + " " + user.Prezime + Environment.NewLine + "Username: " + user.Username +
                Environment.NewLine +
                "IsAdmin: " + user.IsAdmin;

            t.Location = new Point(114, 19);
            t.BackColor = SystemColors.Control;
            t.BorderStyle = BorderStyle.None;
            t.Size = new Size(244, 100);
            t.ReadOnly = true;
            g.Controls.Add(t);

            /*Label l = new Label();
            l.Location = new Point(111, 130);
            l.Size = new Size(120, 13);
            l.Name = "UkupnaCenaLabel";
            l.Text = "Ukupna cena: 0";
            g.Controls.Add(l); 40, 125*/

            Button b = new Button();
            b.Location = new Point(40, 125);
            b.Size = new Size(75, 23);
            b.Name = user.KorisnikId.ToString();
            b.Text = "Izmeni";
            b.Click += Izmeni_User_Click;
            g.Controls.Add(b);

            b = new Button();
            b.Location = new Point(121, 125);
            b.Size = new Size(75, 23);
            b.Name = user.KorisnikId.ToString();
            b.Text = "Rezervacije";
            b.Click += Rezevacije_Click;
            g.Controls.Add(b);
            p.Controls.Add(g);
            UserTabPage.Controls.Add(p);
            Rezevacije_Click(b, null);

            b = new Button();
            b.Location = new Point(201, 125);
            b.Size = new Size(75, 23);
            b.Name = user.KorisnikId.ToString();
            b.Text = "Obrisi";
            b.Enabled = false; // User deletion is intentionally unavailable.
            g.Controls.Add(b);

            b = new Button();
            b.Location = new Point(282, 125);
            b.Size = new Size(75, 23);
            b.Name = user.KorisnikId.ToString();
            b.Text = "Otkazi";
            b.Click += Otkazi_Click;
            g.Controls.Add(b);


        }
        private void Izmeni_User_Click(object sender, EventArgs e)
        {
            textBoxLista.Clear();
            Font f = new Font("Microsoft Sans Serif", 12);
            Button btn = sender as Button;
            Korisnik selected = Funkcije.PronadjiKorisnika(Int32.Parse(btn.Name));
            lastBtn = btn;
            Panel pnl = new Panel();
            foreach (Control cnt in btn.Parent.Parent.Controls)
            {
                if (cnt.Name == "PanelBottom")
                {
                    pnl = cnt as Panel;
                    pnl.Controls.Clear();
                }
            }//1 loc(45, 15)size(30, 20) 2(45, 47)(40,20) 3(45, 79)(70,20) 4(45, 111)(87,20) 5(45, 143)(82,20);    
            Label l = new Label();
            l.Font = f;
            l.Text = "ID:";
            l.Size = new Size(30, 20);
            l.Location = new Point(45, 15);
            pnl.Controls.Add(l);
            l = new Label();
            l.Font = f;
            l.Text = "Ime:";
            l.Size = new Size(40, 20);
            l.Location = new Point(45, 47);
            pnl.Controls.Add(l);
            l = new Label();
            l.Font = f;
            l.Text = "Prezime:";
            l.Size = new Size(70, 20);
            l.Location = new Point(45, 79);
            pnl.Controls.Add(l);
            l = new Label();
            l.Font = f;
            l.Text = "Username:";
            l.Size = new Size(87, 20);
            l.Location = new Point(45, 111);
            pnl.Controls.Add(l);
            l = new Label();
            l.Font = f;
            l.Text = "Passowrd:";
            l.Size = new Size(82, 20);
            l.Location = new Point(45, 143);
            pnl.Controls.Add(l);//1 loc(137, 12)size(115,26) 2(137, 44) 3(137, 76) 4(137, 108) 5(137, 140)
            TextBox t = new TextBox();
            t.Font = f;
            t.Size = new Size(115, 26);
            t.Location = new Point(137, 12);
            t.Name = "UserIdTextBox";
            t.ReadOnly = true;
            t.BackColor = SystemColors.ControlDark;
            t.Text = selected.KorisnikId.ToString();
            pnl.Controls.Add(t);
            //ID TextBox[0]
            textBoxLista.Add(t);
            t = new TextBox();
            t.Font = f;
            t.Size = new Size(115, 26);
            t.Location = new Point(137, 44);
            t.Name = "UserNameTextBox";
            t.Text = selected.Ime;
            pnl.Controls.Add(t);
            //Name TextBox[1]
            textBoxLista.Add(t);
            t = new TextBox();
            t.Font = f;
            t.Size = new Size(115, 26);
            t.Location = new Point(137, 76);
            t.Name = "UserLastnameTextBox";
            t.Text = selected.Prezime;
            pnl.Controls.Add(t);
            //LastName TextBox[2]
            textBoxLista.Add(t);
            t = new TextBox();
            t.Font = f;
            t.Size = new Size(115, 26);
            t.Location = new Point(137, 108);
            t.Name = "UserUsernameTextBox";
            t.Text = selected.Username;
            pnl.Controls.Add(t);
            //UserName TextBox[3]
            textBoxLista.Add(t);
            t = new TextBox();
            t.Font = f;
            t.Size = new Size(115, 26);
            t.Location = new Point(137, 140);
            t.Name = "UserPasswordTextBox";
            t.Text = "";
            t.UseSystemPasswordChar = true;
            pnl.Controls.Add(t);
            //Password TextBox[4]
            textBoxLista.Add(t);
            CheckBox ch = new CheckBox();//(153, 172)(86, 24)
            ch.Font = f;
            ch.RightToLeft = RightToLeft.Yes;
            ch.Location = new Point(153, 172);
            ch.Size = new Size(86, 24);
            ch.Name = "IsAdminCheckBox";
            ch.Text = "IsAdmin";
            ch.Checked = selected.IsAdmin;
            pnl.Controls.Add(ch);
            Button b = new Button();//1save loc(114, 203)size(75, 48) 2cancel(195, 203)
            b.Font = f;
            b.Location = new Point(114, 203);
            b.Size = new Size(75, 48);
            b.Name = "SaveUserButton";
            b.Text = "Save";
            b.Click += SaveUserChanges_Click;
            pnl.Controls.Add(b);
            b = new Button();
            b.Font = f;
            b.Location = new Point(195, 203);
            b.Size = new Size(75, 48);
            b.Name = "CancelUserButton";
            b.Text = "Cancel";
            b.Click += CancelUserChanges_Click;
            pnl.Controls.Add(b);
        }
        private void popuni(List<Rezervacija> lista, Panel pnl)
        {
            pnl.Controls.Clear();
            int pomeraj = 0;

            foreach (Rezervacija rezervacija in lista)
            {
                Destinacija dest = Funkcije.PronadjiDestinaciju(rezervacija);
                GroupBox g = new GroupBox();
                g.Size = new Size(364, 159);
                g.Location = new Point(0, 0 + pomeraj);
                pomeraj += 160;

                PictureBox p = new PictureBox();
                p.Image = TVP_Projekat_3._2.Properties.Resources.user;
                p.Location = new Point(7, 19);
                p.Size = new Size(100, 100);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                g.Controls.Add(p);

                TextBox t = new TextBox();
                t.Multiline = true;

                t.Text = dest.Drzava + "/" + dest.Mesto + Environment.NewLine + Environment.NewLine
                    + "Cena:" + dest.Cena + Environment.NewLine + "Broj osoba:" + rezervacija.BrojRezervisanihMesta
                    + Environment.NewLine + "Ukupna cena:" + rezervacija.UkupnaCena + Environment.NewLine
                    + "Od/Do: " + dest.DatumOd.ToShortDateString() + " | "
                    + dest.DatumDo.ToShortDateString();

                t.Location = new Point(113, 19);
                t.BackColor = SystemColors.Control;
                t.BorderStyle = BorderStyle.None;
                t.Size = new Size(244, 100);
                t.ReadOnly = true;
                g.Controls.Add(t);

                Button b = new Button();
                b.Location = new Point(201, 125);
                b.Size = new Size(75, 23);
                b.Text = "Izmeni";
                //b.Click += Izmeni_Click;
                g.Controls.Add(b);

                b = new Button();
                b.Location = new Point(282, 125);
                b.Size = new Size(75, 23);
                b.Name = rezervacija.RezervacijaId.ToString();
                b.Text = "Otkazi";
                b.Enabled = dest.DatumOd.Date >= DateTime.Today;
                int reservationId=rezervacija.RezervacijaId;
                b.Click += (sender,e) => { if(MessageBox.Show("Otkazati rezervaciju?","Potvrda",MessageBoxButtons.YesNo)==DialogResult.Yes){Funkcije.CancelReservation(reservationId);popuni(lista.Where(r=>r.RezervacijaId!=reservationId).ToList(),pnl);PopuniDestinacije();} };
                g.Controls.Add(b);

                pnl.Controls.Add(g);
            }
        }
        private void PopuniDestinacije()
        {
            panel2.Controls.Clear();
            int pomeraj = 0;

            foreach (Destinacija dest in Funkcije.dest)
            {
                GroupBox g = new GroupBox();
                g.Size = new Size(364, 159);
                g.Location = new Point(0, 0 + pomeraj);
                //g.Bo
                pomeraj += 160;

                PictureBox p = new PictureBox();
                p.Image = TVP_Projekat_3._2.Properties.Resources.user;
                p.Location = new Point(7, 19);
                p.Size = new Size(100, 100);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                g.Controls.Add(p);

                TextBox t = new TextBox();
                t.Multiline = true;
                t.Text = dest.Drzava + "/" + dest.Mesto + Environment.NewLine + Environment.NewLine
                + "Cena:" + dest.Cena + Environment.NewLine + "Broj mesta:" + (dest.UkupnoMesta - dest.Rezervisanih)
                + Environment.NewLine + "Broj dana:" + dest.BrojDana + Environment.NewLine
                + "Od/Do: " + dest.DatumOd.ToShortDateString() + " | "
                   + dest.DatumDo.ToShortDateString();

                t.Location = new Point(114, 19);
                t.BackColor = SystemColors.Control;
                t.BorderStyle = BorderStyle.None;
                t.Size = new Size(244, 100);
                t.ReadOnly = true;
                g.Controls.Add(t);

                /*Label l = new Label();
                l.Location = new Point(111, 130);
                l.Size = new Size(120, 13);
                l.Name = "UkupnaCenaLabel";
                l.Text = "Ukupna cena: 0";
                g.Controls.Add(l);*/

                Button b = new Button();
                b.Location = new Point(201, 125);
                b.Size = new Size(75, 23);
                b.Name = dest.DestinacijaId.ToString();
                b.Text = "Izmeni";
                b.Click += Izmeni_Dest_Click;
                g.Controls.Add(b);

                b = new Button();
                b.Location = new Point(282, 125);
                b.Size = new Size(75, 23);
                b.Name = dest.DestinacijaId.ToString();
                b.Text = "Obrisi";
                b.Click += ObrisiDestinaciju_Click;
                g.Controls.Add(b);

                panel2.Controls.Add(g);
            }
        }


//
//FUNKCIJE
 //

        private void Otkazi_Click(object sender, EventArgs e)
        {
            foreach (Control cont in UserTabPage.Controls)
            {
                if (cont.Name == "InfoPanel")
                {
                    UserTabPage.Controls.Remove(cont); break;
                }
            }
        }
        

        private void CancelUserChanges_Click(object sender, EventArgs e)
        {
            Rezevacije_Click(lastBtn, e);
        }

        private void SaveUserChanges_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            int id=int.Parse(textBoxLista[0].Text);var old=Funkcije.PronadjiKorisnika(id);
            var check=((Button)sender).Parent.Controls.OfType<CheckBox>().FirstOrDefault();
            string password=textBoxLista[4].Text.Length==0?old.Password:Funkcije.HashPassword(textBoxLista[4].Text);
            var user=new Korisnik(id,textBoxLista[1].Text.Trim(),textBoxLista[2].Text.Trim(),textBoxLista[3].Text.Trim(),password,check==null?old.IsAdmin:check.Checked);
            Funkcije.promeniKorisnika(user,id);PopuniKorisnike();Otkazi_Click(sender,e);MessageBox.Show("Korisnik je sacuvan.");
        }

        private void Rezevacije_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel pnl = new Panel();
            foreach (Control cnt in btn.Parent.Parent.Controls)
            {
                if (cnt.Name == "PanelBottom")
                {
                    pnl = cnt as Panel;
                    pnl.Controls.Clear();
                }
            }
            //7, 111,331, 223
            pnl.Name = "PanelBottom";
            pnl.Location = new Point(0, 164);
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Size = new Size(388, 260);
            pnl.AutoScroll = true;

            List<Rezervacija> rez = Funkcije.PronadjiListuRezervacija(Int32.Parse(btn.Name));
            popuni(rez, pnl);
            if (rez.Count == 0)
            {
                Label l = new Label();
                l.Text = "Nema rezervacija";
                l.Location = new Point(120, 100);
                pnl.Controls.Add(l);
            }


            btn.Parent.Parent.Controls.Add(pnl);
        }
        private void Izmeni_Dest_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Destinacija dest = Funkcije.PronadjiDestinaciju(Int32.Parse(btn.Name));

            izmena = true;
            IdTextBox.Text = dest.DestinacijaId.ToString();
            DrzavaTextBox.Text = dest.Drzava;
            MestoTextBox.Text = dest.Mesto;
            CenaTextBox.Text = dest.Cena.ToString();
            BrojDanaTextBox.Text = dest.BrojDana.ToString();
            PopustTextBox.Text = dest.Popust.ToString();
            UkupnoMestaTextBox.Text = dest.UkupnoMesta.ToString();
            DatumOdPicker.MinDate = dest.DatumOd;
            DatumOdPicker.Value = dest.DatumOd;
        }

        //Cancle button u destinacijama
        private void button2_Click(object sender, EventArgs e)
        {
            DrzavaTextBox.Text = "";
            MestoTextBox.Text = "";
            CenaTextBox.Text = "";
            BrojDanaTextBox.Text = "";
            PopustTextBox.Text = "";
            UkupnoMestaTextBox.Text = "";
            DatumOdPicker.MinDate = DateTime.Now;
            DatumOdPicker.Value = DateTime.Now;
            button1.Enabled = false;
            button2.Enabled = false;
            izmena = false;
            IdTextBox.Text = "";
        }
        //Save button u destinacijama
        private void button1_Click(object sender, EventArgs e)
        {
            String drzava, mesto;
            double cena, popust;
            int brojDana, id, ukupnoMesta;
            DateTime datumOd;

            if (!proveriSve()) return;
            id = Int32.Parse(IdTextBox.Text);
            drzava = DrzavaTextBox.Text;
            mesto = MestoTextBox.Text;
            cena = Double.Parse(CenaTextBox.Text);
            brojDana = Int32.Parse(BrojDanaTextBox.Text);
            popust = Double.Parse(PopustTextBox.Text);
            ukupnoMesta = Int32.Parse(UkupnoMestaTextBox.Text);
            datumOd = DatumOdPicker.Value;


            if (cena<=0 || double.IsNaN(cena) || double.IsInfinity(cena) || popust<0 || popust>100 || double.IsNaN(popust) || brojDana<1 || brojDana>365 || ukupnoMesta<1) {MessageBox.Show("Proverite cenu, popust, trajanje i kapacitet.");return;}
            Destinacija destin = new Destinacija(id, drzava.Trim(), mesto.Trim(), cena, popust, brojDana, ukupnoMesta, datumOd);


            Destinacija dest = Funkcije.PronadjiDestinaciju(id);
            //MessageBox.Show(dest.ToString());
            if (dest == null)
            {
                Funkcije.DodajDestinaciju(destin);
            }
            else
            {
                MessageBox.Show(destin.ToString());
                Funkcije.promeniDestinaciju(destin,dest.DestinacijaId);
            }

            button2_Click(sender, e);
            MessageBox.Show("Uspesna izmena!!", "Uspesno");
            PopuniDestinacije();
            button1.Enabled = false;
            button2.Enabled = false;
            DrzavaTextBox.Focus();
        }
        private void ObrisiDestinaciju_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obriete ovu destinaciju?", "Brisanje destinacije", MessageBoxButtons.YesNo);
            if (rezultat == DialogResult.Yes)
            {
                Button b = sender as Button;
                Destinacija dest = Funkcije.PronadjiDestinaciju(Int32.Parse(b.Name));
                if(Funkcije.rezerv.Any(r=>r.DestinacijaId==dest.DestinacijaId)){MessageBox.Show("Destinacija ima rezervacije i ne moze biti obrisana.");return;}
                Funkcije.dest.Remove(dest);
                Funkcije.upisiSve();
                MessageBox.Show("Obrisali ste destinaciju", "Destinacija obrisana");
                PopuniDestinacije();
            }
        }

        private void IdTextBox_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void DestTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!izmena)
            {
                int id = NajmanjiNumber();
                IdTextBox.Text = id.ToString();
            }
            proveriSve();
        }

//
//VALIDACIJA
//

        private bool proveriZaInt(TextBox textBox)
        {
            if (Int32.TryParse(textBox.Text, out int value))
            {

                return true;
            }
            return false;
        }
        private bool proveriZaDouble(TextBox textBox)
        {
            if (Double.TryParse(textBox.Text, out double value))
            {
                return true;
            }
            return false;
        }
        private bool proveriZaNull(TextBox textBox)
        {
            if (textBox.Text == "" || textBox.Text == null)
            {
                return false;
            }

            return true;
        }
        private bool proveriPrazno()
        {
            if (!proveriZaNull(IdTextBox) ||
            !proveriZaNull(DrzavaTextBox) ||
            !proveriZaNull(MestoTextBox) ||
            !proveriZaNull(CenaTextBox) ||
            !proveriZaNull(BrojDanaTextBox) ||
            !proveriZaNull(PopustTextBox) ||
            !proveriZaNull(UkupnoMestaTextBox))
            {
                ErrorLabel.Text = "Sva polja moraju biti popunjena";
                button1.Enabled = false;
                return false;
            }
            return true;
        }
        private bool proveriBroj()
        {
            if (!proveriZaInt(IdTextBox) ||
            !proveriZaDouble(CenaTextBox) ||
            !proveriZaInt(BrojDanaTextBox) ||
            !proveriZaDouble(PopustTextBox) ||
            !proveriZaInt(UkupnoMestaTextBox))
            {
                ErrorLabel.Text = "Neka polja moraju da sadrze samo brojeve";
                button1.Enabled = false;
                return false;
            }
            return true;
        }
        private bool proveriSve()
        {
            if (proveriPrazno() && proveriBroj())
            {
                button1.Enabled = true;
                ErrorLabel.Text = "Sve je ispravno!";
                return true;
            }

            return false;
        }
        private bool ValidateForm()
        {
            //Name TextBox[1]
            //LastName TextBox[2]
            //UserName TextBox[3]
            //Password TextBox[4]
            //Validacija imena i prezimena
            
            if (string.IsNullOrWhiteSpace(textBoxLista[1].Text) || string.IsNullOrWhiteSpace(textBoxLista[2].Text))
            {
                MessageBox.Show("Ime i prezime ne mogu biti prazni.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validacija korisničkog imena
            if (string.IsNullOrWhiteSpace(textBoxLista[3].Text) || textBoxLista[3].Text.Length < 5 || UserNamePostoji(textBoxLista[3].Text))
            {
                MessageBox.Show("Korisničko ime nije ispravnog formata.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validacija lozinke
            
            if (textBoxLista[4].Text.Length > 0 && textBoxLista[4].Text.Length < 8)
            {
                MessageBox.Show("Lozinka mora imati najmanje 8 karaktera i sadržavati kombinaciju slova, brojeva i specijalnih karaktera.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidPassword(string password)
        {
            // Proverava da li lozinka ima najmanje 4 karaktera, bar jedno slovo, jedan broj i bez specijalnih karakter
            return password.Length >= 4 &&
                   Regex.IsMatch(password, @"[A-z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   !Regex.IsMatch(password, @"[\W_]");
        }

        private bool UserNamePostoji(String username)
        {
            foreach (Korisnik k in Funkcije.users)
            {
                if (username == k.Username && k.KorisnikId != Int32.Parse(textBoxLista[0].Text))
                {
                    return true;
                }
            }

            return false;
        }

//
//NESORTIRANO
//




        public static int NajmanjiNumber()
        {
            HashSet<int> ids = new HashSet<int>();

            // Dodaj sve ID-ove u HashSet
            foreach (var obj in Funkcije.dest)
            {
                ids.Add(obj.DestinacijaId);
            }

            int smallestAvailableId = 0;

            // Pronađi najmanji dostupan ID
            while (ids.Contains(smallestAvailableId))
            {
                smallestAvailableId++;
            }

            return smallestAvailableId;
        }
















    }
}
