using GOT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GOT.DBContext
{
    public class GOTContext: DbContext
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
        }
    }
}
