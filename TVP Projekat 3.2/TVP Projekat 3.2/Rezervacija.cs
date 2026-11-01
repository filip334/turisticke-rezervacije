using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_Projekat_3._2
{
    [Serializable]
    public class Rezervacija
    {
        public static int n;
        int rezervacijaId, korisnikId, destinacijaId;
        double ukupnaCena;
        int brojRezervisanihMesta;
        DateTime snimljeno;

        public Rezervacija()
        {
            this.rezervacijaId = -1;
            this.korisnikId = -1;
            this.destinacijaId = -1;
            this.ukupnaCena = 0;
            this.brojRezervisanihMesta = 0;
            this.snimljeno = DateTime.Now;
        }
        public Rezervacija(int rezervacijaId, int korisnikId, int destinacijaId, double ukupnaCena, int brojRezervisanihMesta)
        {
            this.rezervacijaId = rezervacijaId;
            this.korisnikId = korisnikId;
            this.destinacijaId = destinacijaId;
            this.ukupnaCena = ukupnaCena;
            this.brojRezervisanihMesta = brojRezervisanihMesta;
            this.snimljeno = DateTime.Now;
        }

        public Rezervacija(int korisnikId, int destinacijaId, double ukupnaCena, int brojRezervisanihMesta)
        {
            //n = Funkcije.rezerv.Count;
            this.rezervacijaId = n++;
            this.korisnikId = korisnikId;
            this.destinacijaId = destinacijaId;
            this.ukupnaCena = ukupnaCena;
            this.brojRezervisanihMesta = brojRezervisanihMesta;
            this.snimljeno = DateTime.Now;
        }

        public int KorisnikId { get => korisnikId; set => korisnikId = value; }
        public int DestinacijaId { get => destinacijaId; set => destinacijaId = value; }
        public double UkupnaCena { get => ukupnaCena; set => ukupnaCena = value; }
        public int BrojRezervisanihMesta { get => brojRezervisanihMesta; set => brojRezervisanihMesta = value; }
        public DateTime Snimljeno { get => snimljeno; set => snimljeno = value; }
        public int RezervacijaId { get => rezervacijaId; set => rezervacijaId = value; }
        public int KorisnikId1 { get => korisnikId; set => korisnikId = value; }
    }
}
