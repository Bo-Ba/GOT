using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOT.Models
{
    [Table("Zdjecia")]
    public class Zdjecie
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nazwa { get; set; }
        public byte[] Dane { get; set; }
    }
}