using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.DAL.TeamA
{
    public class ClientiGet
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Email { get; set; }

        public string Indirizzo { get; set; }

        public IEnumerable<int> Carrello { get; set; }

    }
}
