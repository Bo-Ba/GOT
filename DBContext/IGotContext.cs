using System.Threading.Tasks;
using GOT.Models;
using Microsoft.EntityFrameworkCore;

namespace GOT.DBContext
{
    public interface IGotContext
    {
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
        int SaveChanges();
        Task SaveChangesAsync();
    }
}
