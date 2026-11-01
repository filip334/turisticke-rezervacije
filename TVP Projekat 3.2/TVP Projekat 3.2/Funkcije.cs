using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
namespace TVP_Projekat_3._2
{
 public class Funkcije
 {
  public static List<Destinacija> dest=new List<Destinacija>();
  public static List<Korisnik> users=new List<Korisnik>();
  public static List<Rezervacija> rezerv=new List<Rezervacija>();
  public class Store { public int Version {get;set;} public List<Destinacija> Destinations {get;set;} public List<Korisnik> Users {get;set;} public List<Rezervacija> Reservations {get;set;} }
  public static string DataPath {get {return Path.Combine(Environment.GetEnvironmentVariable("TOURISM_DATA_DIR") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"FilipProjects","TuristickeRezervacije"),"data.json");}}
  public static void ucitajSve()
  {
   if(!File.Exists(DataPath)) {
    users=new List<Korisnik>{new Korisnik(1,"Demo","Administrator","admin",HashPassword("DemoAdmin123!"),true),new Korisnik(2,"Demo","Putnik","putnik",HashPassword("DemoUser123!"),false)};
    dest=new List<Destinacija>{new Destinacija(1,"Srbija","Zlatibor",120,10,3,20,DateTime.Today.AddDays(30)),new Destinacija(2,"Srbija","Tara",150,0,4,15,DateTime.Today.AddDays(45))};
    rezerv=new List<Rezervacija>();upisiSve();
   }
   var store=new JavaScriptSerializer().Deserialize<Store>(File.ReadAllText(DataPath));
   if(store==null||store.Version!=1||store.Users==null||store.Destinations==null||store.Reservations==null)throw new InvalidDataException("Neispravan format podataka. Originalni fajl nije prepisan.");
   Validate(store);
   users=store.Users;dest=store.Destinations;rezerv=store.Reservations;
   Rezervacija.n=rezerv.Count==0?1:checked(rezerv.Max(r=>r.RezervacijaId)+1);PrebrojRezervisano();
  }
  private static void Validate(Store s)
  {
   if(s.Users.Select(x=>x.KorisnikId).Distinct().Count()!=s.Users.Count||s.Destinations.Select(x=>x.DestinacijaId).Distinct().Count()!=s.Destinations.Count||s.Reservations.Select(x=>x.RezervacijaId).Distinct().Count()!=s.Reservations.Count)throw new InvalidDataException("Duplirani identifikatori.");
   if(!s.Users.Any(x=>x.IsAdmin)||s.Users.Any(x=>string.IsNullOrWhiteSpace(x.Username)||string.IsNullOrWhiteSpace(x.Password)||!x.Password.StartsWith("PBKDF2$"))||s.Users.Select(x=>x.Username.ToUpperInvariant()).Distinct().Count()!=s.Users.Count)throw new InvalidDataException("Neispravni korisnici.");
   foreach(var d in s.Destinations)if(d.Cena<=0||double.IsNaN(d.Cena)||double.IsInfinity(d.Cena)||d.Popust<0||d.Popust>100||double.IsNaN(d.Popust)||d.BrojDana<1||d.UkupnoMesta<1||d.DatumDo<=d.DatumOd)throw new InvalidDataException("Neispravna destinacija.");
   foreach(var r in s.Reservations)if(r.BrojRezervisanihMesta<1||!s.Users.Any(u=>u.KorisnikId==r.KorisnikId)||!s.Destinations.Any(d=>d.DestinacijaId==r.DestinacijaId))throw new InvalidDataException("Neispravna rezervacija.");
   foreach(var d in s.Destinations)if(s.Reservations.Where(r=>r.DestinacijaId==d.DestinacijaId).Sum(r=>r.BrojRezervisanihMesta)>d.UkupnoMesta)throw new InvalidDataException("Prekoracen kapacitet.");
  }
  public static void upisiSve()
  {
   var store=new Store{Version=1,Users=users,Destinations=dest,Reservations=rezerv};Validate(store);
   Directory.CreateDirectory(Path.GetDirectoryName(DataPath));string temp=DataPath+".tmp";
   File.WriteAllText(temp,new JavaScriptSerializer().Serialize(store));
   if(File.Exists(DataPath))File.Replace(temp,DataPath,DataPath+".bak");else File.Move(temp,DataPath);
  }
  public static string HashPassword(string password)
  {
   if(string.IsNullOrWhiteSpace(password)||password.Length<8)throw new ArgumentException("Lozinka mora imati najmanje 8 karaktera.");
   byte[] salt=new byte[16];using(var rng=RandomNumberGenerator.Create())rng.GetBytes(salt);
   using(var derive=new Rfc2898DeriveBytes(password,salt,100000,HashAlgorithmName.SHA256))return "PBKDF2$100000$"+Convert.ToBase64String(salt)+"$"+Convert.ToBase64String(derive.GetBytes(32));
  }
  public static bool VerifyPassword(string password,string encoded)
  {
   try {var parts=encoded.Split('$');if(parts.Length!=4||parts[0]!="PBKDF2")return false;int rounds=int.Parse(parts[1]);if(rounds<100000||rounds>1000000)return false;byte[] expected=Convert.FromBase64String(parts[3]);using(var derive=new Rfc2898DeriveBytes(password,Convert.FromBase64String(parts[2]),rounds,HashAlgorithmName.SHA256)){byte[] actual=derive.GetBytes(32);if(expected.Length!=actual.Length)return false;int diff=0;for(int i=0;i<actual.Length;i++)diff|=actual[i]^expected[i];return diff==0;}}
   catch(FormatException){return false;}catch(ArgumentException){return false;}
  }
  public static Korisnik pronadjiLogin(string username,string password){return users.FirstOrDefault(u=>string.Equals(u.Username,username.Trim(),StringComparison.OrdinalIgnoreCase)&&VerifyPassword(password,u.Password));}
  public static void PrebrojRezervisano(){foreach(var d in dest)d.Rezervisanih=rezerv.Where(r=>r.DestinacijaId==d.DestinacijaId).Sum(r=>r.BrojRezervisanihMesta);}
  public static Destinacija PronadjiDestinaciju(int id){return dest.FirstOrDefault(d=>d.DestinacijaId==id);}
  public static Destinacija PronadjiDestinaciju(Rezervacija r){return PronadjiDestinaciju(r.DestinacijaId);}
  public static Korisnik PronadjiKorisnika(int id){return users.FirstOrDefault(u=>u.KorisnikId==id);}
  public static Rezervacija PronadjiRezervaciju(int id){return rezerv.FirstOrDefault(r=>r.RezervacijaId==id);}
  public static Rezervacija PronajiKorisnikRezervacije(int id){return rezerv.FirstOrDefault(r=>r.KorisnikId==id);}
  public static List<Rezervacija> PronadjiListuRezervacija(int id){return rezerv.Where(r=>r.KorisnikId==id).ToList();}
  public static bool RezervacijaProsla(Rezervacija r){return RezervacijaProsla(PronadjiDestinaciju(r));}
  public static bool RezervacijaProsla(Destinacija d){return d==null||DateTime.Today>d.DatumDo.Date;}
  public static bool RezervacijaTraje(Rezervacija r){var d=PronadjiDestinaciju(r);return d!=null&&DateTime.Today>=d.DatumOd.Date&&DateTime.Today<=d.DatumDo.Date;}
  public static double Price(Destinacija d,int seats){return Math.Round(d.Cena*(1-d.Popust/100)*seats,2);}
  public static Rezervacija SaveReservation(int userId,int destinationId,int seats,int? reservationId=null)
  {
   var d=PronadjiDestinaciju(destinationId);var old=reservationId.HasValue?PronadjiRezervaciju(reservationId.Value):null;
   if(PronadjiKorisnika(userId)==null||d==null||d.DatumOd.Date<DateTime.Today||seats<1)throw new InvalidOperationException("Proverite korisnika, datum i broj mesta.");
   if(reservationId.HasValue&&(old==null||old.KorisnikId!=userId||old.DestinacijaId!=destinationId))throw new InvalidOperationException("Rezervacija nije pronadjena.");
   var others=rezerv.Where(r=>r!=old).ToList();
   if(others.Where(r=>r.DestinacijaId==destinationId).Sum(r=>r.BrojRezervisanihMesta)+seats>d.UkupnoMesta)throw new InvalidOperationException("Nema dovoljno mesta.");
   if(others.Where(r=>r.KorisnikId==userId).Any(r=>{var trip=PronadjiDestinaciju(r);return trip!=null&&d.DatumOd<trip.DatumDo&&trip.DatumOd<d.DatumDo;}))throw new InvalidOperationException("Vec imate rezervaciju u tom periodu.");
   int id=old!=null?old.RezervacijaId:(rezerv.Count==0?1:checked(rezerv.Max(r=>r.RezervacijaId)+1));
   var item=new Rezervacija(id,userId,destinationId,Price(d,seats),seats);int index=old==null?-1:rezerv.IndexOf(old);
   if(index<0)rezerv.Add(item);else rezerv[index]=item;
   try{upisiSve();}catch{if(index<0)rezerv.Remove(item);else rezerv[index]=old;throw;}
   PrebrojRezervisano();return item;
  }
  public static void CancelReservation(int id){var r=PronadjiRezervaciju(id);if(r==null)return;int i=rezerv.IndexOf(r);rezerv.RemoveAt(i);try{upisiSve();}catch{rezerv.Insert(i,r);throw;}PrebrojRezervisano();}
  public static void promeniKorisnika(Korisnik k,int id){int i=users.FindIndex(u=>u.KorisnikId==id);if(i<0)throw new InvalidOperationException("Korisnik nije pronadjen.");var old=users[i];users[i]=k;try{upisiSve();}catch{users[i]=old;throw;}}
  public static void DodajKorsinika(Korisnik k){users.Add(k);try{upisiSve();}catch{users.Remove(k);throw;}}
  public static void DodajDestinaciju(Destinacija d){dest.Add(d);try{upisiSve();}catch{dest.Remove(d);throw;}}
  public static void promeniDestinaciju(Destinacija d,int id){int i=dest.FindIndex(x=>x.DestinacijaId==id);if(i<0)throw new InvalidOperationException("Destinacija nije pronadjena.");var old=dest[i];if(rezerv.Any(r=>r.DestinacijaId==id)&&(d.DatumOd!=old.DatumOd||d.BrojDana!=old.BrojDana))throw new InvalidOperationException("Termin sa rezervacijama ne moze da se pomera.");dest[i]=d;try{upisiSve();}catch{dest[i]=old;throw;}PrebrojRezervisano();}
 }
}
