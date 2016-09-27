using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.DAL.TeamA
{
    [Table("Carrelli", Schema = "TeamA")]
    public class Carrello
    {
        public int Id { get; set; }
        public ICollection<Prodotto> Prodotti { get; set; } = new HashSet<Prodotto>();

    }
}
