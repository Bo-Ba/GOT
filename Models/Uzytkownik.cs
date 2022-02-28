using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Uzytkownicy")]
    [Index(nameof(Email), nameof(NumerLegitymacji), nameof(NrPrzodownika), IsUnique = true)]
    public class Uzytkownik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Imie { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nazwisko { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Haslo { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataUrodzenia { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string NumerLegitymacji { get; set; }

        public int NrPrzodownika { get; set; }

        [Required]
        public int RolaID { get; set; }

        [ForeignKey("RolaID")]
        public Rola Rola { get; set; }

        public List<Odznaka> Odznaki { get; set; }

    }
}
