using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_Projekat_3._2
{
    [Serializable]
    public class Destinacija
    {
        int destinacijaId;
        int rezervisanih;
        String drzava, mesto;
        double cena, popust;
        int brojDana, ukupnoMesta;
        DateTime datumOd, datumDo;

        public Destinacija()
        {
            this.destinacijaId = -1;
            this.drzava = "drzava";
            this.mesto = "mesto";
            this.cena = 0;
            this.popust = 0;
            this.brojDana = 0;
            this.ukupnoMesta = 0;
            this.datumOd = DateTime.Now;
            this.datumDo = datumOd.AddDays(brojDana);
        }

        public Destinacija(int destinacijaId, string drzava, string mesto, double cena, double popust, int brojDana, int ukupnoMesta, DateTime datumOd)
        {
            this.destinacijaId = destinacijaId;
            this.drzava = drzava;
            this.mesto = mesto;
            this.cena = cena;
            this.popust = popust;
            this.brojDana = brojDana;
            this.ukupnoMesta = ukupnoMesta;
            this.datumOd = datumOd;
            this.datumDo = datumOd.AddDays(brojDana);
        }
        public Destinacija(string drzava, string mesto, double cena, double popust, int brojDana, int ukupnoMesta, DateTime datumOd)
        {
            //this.destinacijaId = ;
            this.drzava = drzava;
            this.mesto = mesto;
            this.cena = cena;
            this.popust = popust;
            this.brojDana = brojDana;
            this.ukupnoMesta = ukupnoMesta;
            this.datumOd = datumOd;
            this.datumDo = datumOd.AddDays(brojDana);
        }

        public int DestinacijaId { get => destinacijaId; set => destinacijaId = value; }
        public int Rezervisanih { get => rezervisanih; set => rezervisanih = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        public string Mesto { get => mesto; set => mesto = value; }
        public double Cena { get => cena; set => cena = value; }
        public double Popust { get => popust; set => popust = value; }
        public int BrojDana { get => brojDana; set => brojDana = value; }
        public int UkupnoMesta { get => ukupnoMesta; set => ukupnoMesta = value; }
        public DateTime DatumOd { get => datumOd; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo; set => datumDo = value; }

        public override string ToString()
        {
            /*int destinacijaId;
            int rezervisanih;
            String drzava, mesto;
            double cena, popust;
            int brojDana, ukupnoMesta;
            DateTime datumOd, datumDo;*/
            return destinacijaId + " " + drzava + " " + mesto + Environment.NewLine + cena + "  " + popust + " " + rezervisanih + "  " + ukupnoMesta + " " + brojDana + Environment.NewLine + datumOd + "  " + datumDo;
        }
    }
}
