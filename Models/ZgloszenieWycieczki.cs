using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("ZgloszeniaWycieczek")]
    public class ZgloszenieWycieczki
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataZgloszenia { get; set; }

        [Required]
        public int Punkty { get; set; }
        
        [Required]
        public int Status { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataZmianyStatusu { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataOdbyciaWycieczki { get; set; }

        [Required]
        public int WycieczkaID { get; set; }

        [ForeignKey("WycieczkaID")]
        public Wycieczka Wycieczka { get; set; }

        [Required]
        public int OdznakaID { get; set; }
        
        [ForeignKey("OdznakaID")]
        public Odznaka Odznaka { get; set; }

        [Required]
        public int TurystaID { get; set; }
        
        [ForeignKey("TurystaID")]
        public Uzytkownik Turysta { get; set; }

        public int PrzodownikID { get; set; }

        [ForeignKey("PrzodownikID")]
        public Uzytkownik Przodownik { get; set; }


        public List<Zdjecie> Zdjecia { get; set; }
    }
}
