using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamA
{
    [Table("Carrelli", Schema = "TeamA")]
    public class Carrello
    {
        public int Id { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime DataUltimaModifica { get; set; }
        public ICollection<RigaCarrello> Righe { get; set; }
        public Carrello()
        {
            DataCreazione = DateTime.UtcNow;
            DataUltimaModifica = DataCreazione;
            this.Righe = new HashSet<RigaCarrello>();
        }
    }
}
