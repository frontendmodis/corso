using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamC
{
    [Table("Fatture", Schema = "TeamC")]
    public class Fattura
    {
        public int Id { get; set; }
        [Required]
        public Ordine Ordine { get; set; }
        public string NumeroFattura { get; set; }
        public DateTime DataFattura { get; set; }
    }
}
