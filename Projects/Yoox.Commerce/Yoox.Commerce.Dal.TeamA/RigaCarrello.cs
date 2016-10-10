using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamA
{
    [Table("RigheCarrello", Schema = "TeamA")]
    public class RigaCarrello
    {
        public int Id { get; set; }
        [Required]
        public Carrello Carrello { get; set; }
        public int ProdottoId { get; set; }
        public int Quantita { get; set; }
    }
}
