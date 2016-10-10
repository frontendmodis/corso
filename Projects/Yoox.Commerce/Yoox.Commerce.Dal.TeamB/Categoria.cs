using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamB
{
    [Table("Categorie", Schema = "TeamB")]
    public class Categoria
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(150)]
        public string Nome { get; set; }
        public ICollection<Prodotto> Prodotti { get; set; }
        public Categoria()
        {
            this.Prodotti = new HashSet<Prodotto>();
        }
    }
}
