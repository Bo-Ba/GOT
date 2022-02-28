using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Odznaki")]
    public class Odznaka
    {
        [Key] public int ID { get; set; }

        public int Rodzaj { get; set; }
        public int Stopien { get; set; }
        public int WymaganePunkty { get; set; }
        public int? PunktyPrzeniesione { get; set; }
        public int UzytkownikID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime? DataZdobycia { get; set; }

        [ForeignKey("UzytkownikID")] public Uzytkownik Uzytkownik { get; set; }

        [NotMapped]
        public static Dictionary<int, string> rodzaj { get; } = new Dictionary<int, string>()
        {
            { 0, "Popularna" },
            { 1, "Mała" },
        };

        [NotMapped]
        public static Dictionary<int, string> stopien { get; } = new Dictionary<int, string>()
        {
            { 0, "popularna" },
            { 1, "brazowa" },
            { 2, "srebrna" },
            { 3, "zlota" },
        };
        [NotMapped]
        public static Dictionary<int, string> stopienPl { get; } = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "brązowa" },
            { 2, "srebrna" },
            { 3, "złota" },
        };
    }
}