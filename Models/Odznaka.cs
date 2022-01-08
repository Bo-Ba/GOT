using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Odznaki")]
    public class Odznaka
    {
        [Key]
        public int ID { get; set; }

        public int Rodzaj { get; set; }
        public int Stopien { get; set; }
        public int WymaganePunkty { get; set; }
        public int PunktyPrzeniesione { get; set; }
        public int UzytkownikID { get; set; }

        [ForeignKey("UzytkownikID")]
        public Uzytkownik Uzytkownik { get; set; }
    }
}
