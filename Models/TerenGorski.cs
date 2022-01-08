using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOT.Models
{
    [Table("TerenyGorskie")]
    public class TerenGorski
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nazwa { get; set; }

        public List<PunktTrasy> PunktyTrasy { get; set; }
    }
}