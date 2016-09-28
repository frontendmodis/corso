using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL
{
    [Table("Persone")]
    public class Persona
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Nome { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Cognome { get; set; }
        public int? Gruppo_Id { get; set; }
        public Gruppo Gruppo { get; set; }
        public ICollection<Recapito> Recapiti { get; set; }

        public Persona()
        {
            this.Recapiti = new HashSet<Recapito>();
        }
    }
}
