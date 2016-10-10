using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamA
{
    [Table("Clienti", Schema = "TeamA")]
    public class Cliente
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(30)]
        public string Nome { get; set; }
        [Required, MinLength(2), MaxLength(30)]
        public string Cognome { get; set; }
        public Carrello Carrello { get; set; }
    }
}
