using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.DAL.TeamA
{

    // un altro progetto, se linka il mio, non vede Cliente con internal
    [Table("Clienti",Schema = "TeamA")]
    public class Cliente
    {

        public int Id { get; set; }

        [Required,MinLength(1),MaxLength(50)]
        public string Nome { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string Cognome { get; set; }

        [Required, MinLength(5), MaxLength(255)]
        public string Email { get; set; }


        public string Indirizzo { get; set; }

        public Carrello Carrello { get; set; }
        
    
    }
}
