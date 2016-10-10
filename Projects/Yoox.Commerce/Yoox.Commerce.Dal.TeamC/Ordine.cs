using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamC
{
    [Table("Ordine", Schema = "TeamC")]
    public class Ordine
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [Required, MinLength(2), MaxLength(30)]
        public string ClienteNome { get; set; }
        [Required, MinLength(2), MaxLength(30)]
        public string ClienteCognome { get; set; }
        [Required, MinLength(2), MaxLength(250)]
        public string ClienteIndirizzoSpedizione { get; set; }
        [Required, MinLength(2), MaxLength(250)]
        public string ClienteIndirizzoFatturazione { get; set; }
        public string NumeroOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public DateTime? DataChiusuraOrdine { get; set; }
        public StatoOrdine Stato { get; set; }
        public ICollection<RigaOrdine> Righe { get; set; }
        public decimal CostiSpedizione { get; set; }
        public Fattura Fattura { get; set; }

        public Ordine()
        {
            this.DataOrdine = DateTime.UtcNow;
            this.Righe = new HashSet<RigaOrdine>();
        }
    }
}
