using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamC
{
    [Table("RigheOrdini", Schema = "TeamC")]
    public class RigaOrdine
    {
        public int Id { get; set; }
        [Required]
        public Ordine Ordine { get; set; }
        public int ProdottoId { get; set; }
        public int QuantitaOrdinata { get; set; }
        public int QuantitaEvasa { get; set; }
        public decimal PrezzoUnitario { get; set; }
        public decimal PrezzoTotale { get; set; }
    }
}
