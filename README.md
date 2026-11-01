# Turističke rezervacije 3.2

C# Windows Forms / .NET Framework 4.7.2. Otvorite TVP Projekat 3.2/TVP Projekat 3.2.sln u Visual Studio-u i F5. Aplikacija sada otvara prijavu.

Demo nalozi (samo izmišljeni podaci): admin / DemoAdmin123!, putnik / DemoUser123!.

Prvo pokretanje stvara novu JSON bazu u %LOCALAPPDATA%/FilipProjects/TuristickeRezervacije/data.json. Lozinke su PBKDF2-SHA256 sa slučajnom soli. Upis zamenjuje ceo fajl i čuva data.json.bak. Testovi koriste TOURISM_DATA_DIR kao zaseban folder. Sačuvajte kopiju ovog foldera kada je aplikacija zatvorena.

Stari bin/Debug/txt podaci su sačuvani, nisu automatski učitani niti izloženi u paketu za GitHub. Nova verzija radi sa novim demo podacima, bez BinaryFormatter-a.

Podržani su prijava, ponude, filteri, rezervisanje, izmena broja mesta, otkazivanje i istorija. Administrator menja korisnike i destinacije; prazno polje lozinke ostavlja postojeću. Datumi destinacije sa rezervacijama ne mogu se pomerati. Brisanje korisnika nije podržano; dugme je onemogućeno.

Lokalni školski demo, bez mrežnog servera, naplate i istovremenog rada više korisnika. Nije produkcioni sistem autentifikacije.
