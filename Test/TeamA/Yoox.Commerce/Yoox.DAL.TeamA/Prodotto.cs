using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.DAL.TeamA
{
    [Table("Prodotti", Schema = "TeamA")]
    public class Prodotto
    {
        public int Id { get; set; }

    }
}
