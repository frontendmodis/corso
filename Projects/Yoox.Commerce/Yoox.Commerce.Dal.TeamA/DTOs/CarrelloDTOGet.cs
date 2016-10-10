using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamA.DTOs
{
    public class CarrelloDTOGet
    {
        public int Id { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime DataUltimaModifica { get; set; }
        public IEnumerable<RigaCarrelloDTOGet> Righe { get; set; }
    }

    public class RigaCarrelloDTOGet
    {
        public int Id { get; set; }
        public int ProdottoId { get; set; }
        public int Quantita { get; set; }
    }
}
