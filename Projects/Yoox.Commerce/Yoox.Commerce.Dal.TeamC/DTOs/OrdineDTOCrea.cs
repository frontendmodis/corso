using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamC.DTOs
{
    public class OrdineDTOCrea
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCognome { get; set; }
        public string ClienteIndirizzoSpedizione { get; set; }
        public string ClienteIndirizzoFatturazione { get; set; }
        public string NumeroOrdine { get; set; }
        public decimal CostiSpedizione { get; set; }
    
        public IEnumerable<RigaOrdineDTOCrea> Righe { get; set; }
    }

    public class RigaOrdineDTOCrea
    {
        public int ProdottoId { get; set; }
        public int QuantitaOrdinata { get; set; }
        public decimal PrezzoUnitario { get; set; }
    }
}
