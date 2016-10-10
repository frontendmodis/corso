using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamB
{
    [Table("Prodotti", Schema = "TeamB")]
    public class Prodotto
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(150)]
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public ICollection<Categoria> Categorie { get; set; }

        public Prodotto()
        {
            this.Categorie = new HashSet<Categoria>();
        }
    }
}
