using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOT.Models
{
    [Table("PunktyTrasy")]
    [Index(nameof(Nazwa), IsUnique = true)]
    public class PunktTrasy
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nazwa { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal SzerokoscGeo { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal DlugoscGeo { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal WysokoscNPM { get; set; }

        public List<TerenGorski> TerenyGorskie { get; set; }
    }
}