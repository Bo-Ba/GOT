using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Wycieczki")]
    public class Wycieczka
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DataUtworzeznia { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Nazwa { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool CzyPubliczna { get; set; }

        [Required]
        public int AutorID { get; set; }
        [Required]
        public decimal Dlugosc { get; set; }
        [Required]
        public decimal SumaPodejsc { get; set; }

        [ForeignKey("AutorID")]
        public Uzytkownik Autor { get; set; }

        public List<Trasa> Trasy { get; set; }

        public List<ZgloszenieWycieczki> Zgloszenia { get; set; }

    }
}
