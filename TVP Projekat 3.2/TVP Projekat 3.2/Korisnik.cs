using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_Projekat_3._2
{
    [Serializable]
    public class Korisnik
    {

        int korisnikId;
        String ime, prezime, username, password;
        bool isAdmin;
        public Korisnik()
        {
            korisnikId = -1;
            ime = "";
            prezime = "";
            username = "";
            password = "";
            isAdmin = false;
        }

        public Korisnik(int korisnikId, string ime, string prezime, string username, string password, bool isAdmin)
        {
            this.korisnikId = korisnikId;
            this.ime = ime;
            this.prezime = prezime;
            this.username = username;
            this.password = password;
            this.isAdmin = isAdmin;
        }
        public Korisnik(string ime, string prezime, string username, string password, bool isAdmin)
        {
            //this.korisnikId = ;
            this.ime = ime;
            this.prezime = prezime;
            this.username = username;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public int KorisnikId { get => korisnikId; set => korisnikId = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
