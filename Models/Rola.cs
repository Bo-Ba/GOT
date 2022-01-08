using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    [Table("Role")]
    public class Rola
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Nazwa { get; set; }
    }
}
