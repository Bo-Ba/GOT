using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOT.DBContext;
using GOT.Models;
using GoTestsN.FakeSets;
using Microsoft.EntityFrameworkCore;

namespace GoTestsN
{
    public class FakeGotContext : IGotContext
    {
        public FakeGotContext()
        {
            this.Trasy = new FakeTrasaSet();
            this.Wycieczki = new FakeWycieczkaSet();
            this.Odznaki = new FakeOdznakaSet();
            this.ZgloszeniaWycieczek = new FakeZgloszenieWycieczkiSet();
            this.PunktyTrasy = new FakePunktTrasySet();
            this.Role = new FakeRoleSet();
            this.TerenyGorskie = new FakeTerenGorskiSet();
            this.Uzytkownicy = new FakeUzytkownikSet();
        }
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

        public int SaveChanges()
        {
            return 0;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
