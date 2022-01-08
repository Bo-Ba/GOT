using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Utrudnienia")]
    public class Utrudnienie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varcahr(50)")]
        public string Nazwa { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Opis { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataWystapienia { get; set; }

        [Required]
        public int TrasaID { get; set; }

        [ForeignKey("TrasaID")]
        public Trasa Trasa { get; set; }

        [Required]
        public int ZglaszajacyID { get; set; }
        [ForeignKey("ZglaszajacyID")]
        public Uzytkownik Zglaszajacy { get; set; }

        [Required]
        public bool Zweryfikowane { get; set; }

        public int WeryfikujacyID { get; set; }
        
        [ForeignKey("WeryfikujacyID")]
        public Uzytkownik Weryfikujacy { get; set; }
    }
}
