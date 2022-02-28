using System;
using System.Globalization;
using GOT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using GOT.Migrations;
using GoTestsN;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Threading.Tasks;

namespace GOT.DBContext
{
    public class GOTContext: DbContext, IGotContext
    {
        public string DbPath { get; private set; }

        public DbSet<Odznaka> Odznaki { get; set; }
        public DbSet<PunktTrasy> PunktyTrasy { get; set; }
        public DbSet<Rola> Role { get; set; }
        public DbSet<TerenGorski> TerenyGorskie { get; set; }
        public DbSet<Trasa> Trasy { get; set; }
        public DbSet<Utrudnienie> Utrudnienia { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Wycieczka> Wycieczki { get; set; }
        public DbSet<Zdjecie> Zdjecia { get; set; }
        public DbSet<ZgloszenieWycieczki> ZgloszeniaWycieczek { get; set; }

        public GOTContext() 
        {
            DbPath = $"{Directory.GetCurrentDirectory()}/got.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("got");
            modelBuilder.Entity<Rola>(x =>
            {
                x.HasData(new Rola() { ID = 1, Nazwa = "Turysta" });
                x.HasData(new Rola() { ID = 2, Nazwa = "Przodownik" });
                x.HasData(new Rola() { ID = 3, Nazwa = "Pracownik PTTK" });
            });

            modelBuilder.Entity<Uzytkownik>(x =>
            {
                x.HasData(new Uzytkownik()
                {
                    ID = 1, Email = "test", Imie = "Jan", Nazwisko = "Kowalski",
                    DataUrodzenia = new DateTime(2000, 1, 15), Haslo = "test", RolaID = 1,
                });
                x.HasData(new Uzytkownik()
                {
                    ID = 2, Email = "test", Imie = "Jan", Nazwisko = "Test", DataUrodzenia = new DateTime(2000, 1, 15),
                    Haslo = "test", RolaID = 1,
                });
                x.HasData(new Uzytkownik()
                {
                    ID = 3, Email = "test", Imie = "Jan", Nazwisko = "Drugi", DataUrodzenia = new DateTime(2000, 1, 15),
                    Haslo = "test", RolaID = 1,
                });
            });

            modelBuilder.Entity<Odznaka>(x =>
            {
                x.HasData(new Odznaka()
                {
                    ID = 1, Rodzaj = 0, Stopien = 0, WymaganePunkty = 60, UzytkownikID = 1,
                    DataZdobycia = new DateTime(2000, 1, 6)
                });
                x.HasData(new Odznaka() { ID = 2, Rodzaj = 1, Stopien = 1, WymaganePunkty = 120, UzytkownikID = 1 });
                x.HasData(new Odznaka() { ID = 3, Rodzaj = 1, Stopien = 2, WymaganePunkty = 360, UzytkownikID = 1 });
                x.HasData(new Odznaka() { ID = 4, Rodzaj = 1, Stopien = 3, WymaganePunkty = 720, UzytkownikID = 1 });

                x.HasData(new Odznaka()
                    { ID = 5, Rodzaj = 0, Stopien = 0, PunktyPrzeniesione = 0, WymaganePunkty = 60, UzytkownikID = 2 });
                x.HasData(new Odznaka()
                {
                    ID = 6, Rodzaj = 1, Stopien = 1, PunktyPrzeniesione = 0, WymaganePunkty = 120, UzytkownikID = 2
                });
                x.HasData(new Odznaka()
                {
                    ID = 7, Rodzaj = 1, Stopien = 2, PunktyPrzeniesione = 0, WymaganePunkty = 360, UzytkownikID = 2
                });
                x.HasData(new Odznaka()
                {
                    ID = 8, Rodzaj = 1, Stopien = 3, PunktyPrzeniesione = 0, WymaganePunkty = 720, UzytkownikID = 2
                });

                x.HasData(new Odznaka()
                    { ID = 9, Rodzaj = 0, Stopien = 0, PunktyPrzeniesione = 0, WymaganePunkty = 60, UzytkownikID = 3 });
                x.HasData(new Odznaka()
                {
                    ID = 10, Rodzaj = 1, Stopien = 1, PunktyPrzeniesione = 0, WymaganePunkty = 120, UzytkownikID = 3
                });
                x.HasData(new Odznaka()
                {
                    ID = 11, Rodzaj = 1, Stopien = 2, PunktyPrzeniesione = 0, WymaganePunkty = 360, UzytkownikID = 3
                });
                x.HasData(new Odznaka()
                {
                    ID = 12, Rodzaj = 1, Stopien = 3, PunktyPrzeniesione = 0, WymaganePunkty = 720, UzytkownikID = 3
                });
            });

            modelBuilder.Entity<Wycieczka>(x =>
            {
                x.HasData(new Wycieczka()
                {
                    ID = 1, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2000, 1, 1),
                });
                x.HasData(new Wycieczka()
                {
                    ID = 2, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2001, 1, 2),
                });
                x.HasData(new Wycieczka()
                {
                    ID = 3, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2002, 1, 3),
                });
                x.HasData(new Wycieczka()
                {
                    ID = 4, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2003, 1, 4),
                });
                x.HasData(new Wycieczka()
                {
                    ID = 5, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2004, 1, 5),
                });
                x.HasData(new Wycieczka()
                {
                    ID = 6, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2005, 1, 6),
                });
                ;
                x.HasData(new Wycieczka()
                {
                    ID = 7, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2005, 1, 6),
                });
                ;
                x.HasData(new Wycieczka()
                {
                    ID = 8, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2005, 1, 6),
                });
                ;
                x.HasData(new Wycieczka()
                {
                    ID = 9, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2005, 1, 6),
                });
                ;
                x.HasData(new Wycieczka()
                {
                    ID = 10, Dlugosc = 1.5M, AutorID = 1, CzyPubliczna = true, Nazwa = "Test", SumaPodejsc = 0.2M,
                    DataUtworzeznia = new DateTime(2005, 1, 6),
                });
                ;
            });

            modelBuilder.Entity<ZgloszenieWycieczki>(x =>
            {
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 1, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 1, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2000, 1, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 2, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 2, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2000, 2, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 3, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 3, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2000, 3, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 4, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 4, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2000, 4, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 5, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 5, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2000, 5, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 6, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 6, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2003, 6, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 7, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 7, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2003, 6, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 8, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 8, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2003, 6, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 9, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 9, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2003, 6, 1),
                });
                x.HasData(new ZgloszenieWycieczki()
                {
                    ID = 10, TurystaID = 1, OdznakaID = 1, Punkty = 10, WycieczkaID = 10, PrzodownikID = 1,
                    DataOdbyciaWycieczki = new DateTime(2003, 6, 1),
                });
            });

            modelBuilder.Entity<TerenGorski>(x =>
            {
                x.HasData(new TerenGorski() { ID = 1, Nazwa = "Sudety" });
                x.HasData(new TerenGorski() { ID = 2, Nazwa = "Tatry wysokie" });
                x.HasData(new TerenGorski() { ID = 3, Nazwa = "Karkonosze" });
                x.HasData(new TerenGorski() { ID = 4, Nazwa = "Bieszczady" });

            });

            modelBuilder.Entity<PunktTrasy>(x =>
            {
                string[] lat = System.IO.File.ReadAllLines(@"C:\Users\kajtu\Desktop\lat.txt");
                string[] lon = System.IO.File.ReadAllLines(@"C:\Users\kajtu\Desktop\lon.txt");
                string[] names = System.IO.File.ReadAllLines(@"C:\Users\kajtu\Desktop\nazwy.txt");
                int counter = 1;
                foreach (var name in names)
                {
                    x.HasData(new PunktTrasy()
                    {
                        ID = counter, Nazwa = name,
                        DlugoscGeo = Convert.ToDecimal(lon[counter - 1], new CultureInfo("en-US")),
                        SzerokoscGeo = Convert.ToDecimal(lat[counter - 1], new CultureInfo("en-US")), WysokoscNPM = 0
                    });
                    counter++;
                }

                x.HasData(new PunktTrasy
                {
                    ID = 35, Nazwa = "Rusinowa Polana", SzerokoscGeo = 49.262862m, DlugoscGeo = 20.090297m,
                    WysokoscNPM = 1210
                });

                x.HasData(new PunktTrasy
                {
                    ID = 36, Nazwa = "Dolina Filipka", SzerokoscGeo = 49.282190m, DlugoscGeo = 20.087708m,
                    WysokoscNPM = 959,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 37, Nazwa = "Gęsia Szyja", SzerokoscGeo = 49.259054m, DlugoscGeo = 20.076541m,
                    WysokoscNPM = 1489,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 38, Nazwa = "Psia Trawka", SzerokoscGeo = 49.259054m, DlugoscGeo = 20.076541m,
                    WysokoscNPM = 1489,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 39, Nazwa = "Czarny Staw nad Morskim Okiem", SzerokoscGeo = 49.190374m,
                    DlugoscGeo = 20.073700m,
                    WysokoscNPM = 1583,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 40, Nazwa = "Siklawa", SzerokoscGeo = 49.212372m, DlugoscGeo = 20.042302m, WysokoscNPM = 1666,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 41, Nazwa = "Śnieżka", SzerokoscGeo = 50.736103m, DlugoscGeo = 15.739742m, WysokoscNPM = 1602,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 42, Nazwa = "Przełęcz pod Śnieżką", SzerokoscGeo = 50.740381m, DlugoscGeo = 15.724517m,
                    WysokoscNPM = 1385,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 43, Nazwa = "Połonina Wetlińska", SzerokoscGeo = 49.150540m, DlugoscGeo = 22.556300m,
                    WysokoscNPM = 1255,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 44, Nazwa = "Wetlina", SzerokoscGeo = 49.148035m, DlugoscGeo = 22.477630m, WysokoscNPM = 651,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 45, Nazwa = "Przełęcz Orłowicza", SzerokoscGeo = 49.180770m, DlugoscGeo = 22.491975m,
                    WysokoscNPM = 1099,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 46, Nazwa = "Suche Rzeki", SzerokoscGeo = 49.201962m, DlugoscGeo = 22.525090m,
                    WysokoscNPM = 609,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 47, Nazwa = "Zatwarnica", SzerokoscGeo = 49.227500m, DlugoscGeo = 22.553183m,
                    WysokoscNPM = 512,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 48, Nazwa = "Schronisko PTTK na Połoninie Wetlińskiej", SzerokoscGeo = 49.157159m,
                    DlugoscGeo = 22.549613m, WysokoscNPM = 1179,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 49, Nazwa = "Moczarne", SzerokoscGeo = 49.143195m, DlugoscGeo = 22.489573m, WysokoscNPM = 674,
                });

                x.HasData(new PunktTrasy
                {
                    ID = 50, Nazwa = "Mała Rawka", SzerokoscGeo = 49.109681m, DlugoscGeo = 22.573857m,
                    WysokoscNPM = 1272,
                });

            });

            modelBuilder.Entity<Trasa>(x =>
            {
                Random randObj = new Random();
                x.HasData(new Trasa()
                {
                    ID = 1, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 1, PunktKoncowyID = 2, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 2, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 2, PunktKoncowyID = 1, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 3, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 2, PunktKoncowyID = 3, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 4, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 3, PunktKoncowyID = 2, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 5, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 2, PunktKoncowyID = 4, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 6, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 4, PunktKoncowyID = 2, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 7, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 2, PunktKoncowyID = 5, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 8, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 5, PunktKoncowyID = 2, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 9, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 5, PunktKoncowyID = 6, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 10, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 6, PunktKoncowyID = 5, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 11, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 6, PunktKoncowyID = 5, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 12, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 6, PunktKoncowyID = 7, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 13, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 7, PunktKoncowyID = 6, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 14, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 7, PunktKoncowyID = 6, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 15, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 7, PunktKoncowyID = 8, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 16, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 8, PunktKoncowyID = 7, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 17, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 8, PunktKoncowyID = 7, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 18, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 8, PunktKoncowyID = 9, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 55, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 9, PunktKoncowyID = 8, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 20, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 9, PunktKoncowyID = 10, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 21, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 10, PunktKoncowyID = 9, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 22, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 10, PunktKoncowyID = 11, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 23, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 10, PunktKoncowyID = 12, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 24, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 11, PunktKoncowyID = 13, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 25, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 11, PunktKoncowyID = 14, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 26, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 12, PunktKoncowyID = 13, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 27, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 12, PunktKoncowyID = 14, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 28, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 14, PunktKoncowyID = 15, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 29, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 13, PunktKoncowyID = 15, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 30, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 15, PunktKoncowyID = 16, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 31, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 16, PunktKoncowyID = 17, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 32, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 16, PunktKoncowyID = 34, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 33, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 16, PunktKoncowyID = 34, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 34, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 16, PunktKoncowyID = 19, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 35, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 16, PunktKoncowyID = 20, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 36, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 15, PunktKoncowyID = 19, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 37, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 15, PunktKoncowyID = 20, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 38, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 19, PunktKoncowyID = 20, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 39, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 20, PunktKoncowyID = 21, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 54, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 20, PunktKoncowyID = 21, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 40, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 20, PunktKoncowyID = 22, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 41, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 21, PunktKoncowyID = 22, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 42, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 22, PunktKoncowyID = 23, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 43, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 22, PunktKoncowyID = 24, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 44, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 21, PunktKoncowyID = 23, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 45, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 21, PunktKoncowyID = 24, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 46, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 24, PunktKoncowyID = 25, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 47, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 21, PunktKoncowyID = 24, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 48, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 25, PunktKoncowyID = 28, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 49, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 28, PunktKoncowyID = 30, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 50, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 31, PunktKoncowyID = 30, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 51, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 30, PunktKoncowyID = 31, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 52, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 31, PunktKoncowyID = 32, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 53, Dlugosc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 100), 2),
                    PunktStartowyID = 32, PunktKoncowyID = 33, TerenGorskiID = 1, PunktyZaTrase = 1,
                    SumaPodejsc = Decimal.Round(Convert.ToDecimal(randObj.NextDouble() * 10), 2), StatusTrasy = 1
                });
                x.HasData(new Trasa()
                {
                    ID = 79, PunktStartowyID = 35, PunktKoncowyID = 36, PunktyZaTrase = 3, Dlugosc = 2.9m,
                    StatusTrasy = 1, TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 80, PunktKoncowyID = 35, PunktStartowyID = 36, PunktyZaTrase = 6, Dlugosc = 2.9m,
                    StatusTrasy = 1, TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 56, PunktStartowyID = 37, PunktKoncowyID = 35, PunktyZaTrase = 1, Dlugosc = 1.3m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 57, PunktKoncowyID = 37, PunktStartowyID = 35, PunktyZaTrase = 4, Dlugosc = 1.3m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 58, PunktStartowyID = 42, PunktKoncowyID = 41, PunktyZaTrase = 3, Dlugosc = 1.4m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 59, PunktKoncowyID = 42, PunktStartowyID = 41, PunktyZaTrase = 3, Dlugosc = 1.4m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 60, PunktKoncowyID = 42, PunktStartowyID = 41, PunktyZaTrase = 3, Dlugosc = 1.4m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 61, PunktStartowyID = 43, PunktKoncowyID = 44, PunktyZaTrase = 4, Dlugosc = 10.1m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 62, PunktStartowyID = 44, PunktKoncowyID = 43, PunktyZaTrase = 10, Dlugosc = 10.1m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 63, PunktStartowyID = 44, PunktKoncowyID = 43, PunktyZaTrase = 10, Dlugosc = 10.1m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 64, PunktStartowyID = 43, PunktKoncowyID = 45, PunktyZaTrase = 3, Dlugosc = 6.6m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 65, PunktStartowyID = 45, PunktKoncowyID = 43, PunktyZaTrase = 5, Dlugosc = 6.6m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 66, PunktStartowyID = 43, PunktKoncowyID = 46, PunktyZaTrase = 5, Dlugosc = 11m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 67, PunktStartowyID = 46, PunktKoncowyID = 43, PunktyZaTrase = 11, Dlugosc = 11m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 68, PunktStartowyID = 46, PunktKoncowyID = 43, PunktyZaTrase = 11, Dlugosc = 11m,
                    StatusTrasy = 1,
                    TerenGorskiID = 2
                });
                x.HasData(new Trasa()
                {
                    ID = 69, PunktStartowyID = 43, PunktKoncowyID = 47, PunktyZaTrase = 8, Dlugosc = 14.6m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 70, PunktStartowyID = 47, PunktKoncowyID = 43, PunktyZaTrase = 16, Dlugosc = 14.6m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 71, PunktStartowyID = 43, PunktKoncowyID = 48, PunktyZaTrase = 3, Dlugosc = 2.2m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 72, PunktStartowyID = 48, PunktKoncowyID = 43, PunktyZaTrase = 3, Dlugosc = 2.2m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 73, PunktStartowyID = 47, PunktKoncowyID = 46, PunktyZaTrase = 7, Dlugosc = 3.6m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 74, PunktStartowyID = 46, PunktKoncowyID = 47, PunktyZaTrase = 5, Dlugosc = 3.6m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 75, PunktStartowyID = 49, PunktKoncowyID = 44, PunktyZaTrase = 5, Dlugosc = 3.4m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 76, PunktStartowyID = 44, PunktKoncowyID = 49, PunktyZaTrase = 6, Dlugosc = 3.4m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 77, PunktStartowyID = 49, PunktKoncowyID = 50, PunktyZaTrase = 5, Dlugosc = 5.9m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });
                x.HasData(new Trasa()
                {
                    ID = 78, PunktStartowyID = 50, PunktKoncowyID = 49, PunktyZaTrase = 11, Dlugosc = 5.9m,
                    StatusTrasy = 1,
                    TerenGorskiID = 4
                });

            });
        }

        public Task SaveChangesAsync()
        {
           return base.SaveChangesAsync();
        }
    }
}
