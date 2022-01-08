using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Trasy")]
    public class Trasa
    {
        [Key]
        public int ID { get; set; }
        
        public int PunktyZaTrase { get; set; }

        public int StatusTrasy { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Dlugosc { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal SumaPodejsc { get; set; }

        public int PunktStartowyID { get; set; }

        [ForeignKey("PunktStartowyID")]
        public PunktTrasy PunktStartowy { get; set; }

        public int PunktKoncowyID { get; set; }

        [ForeignKey("PunktKoncowyID")]
        public PunktTrasy PunktKoncowy { get; set; }

        public int TerenGorskiID { get; set; }

        [ForeignKey("TerenGorskiID")]
        public TerenGorski TerenGorski { get; set; }

        public List<Wycieczka> Wycieczki { get; set; }
    }
}
