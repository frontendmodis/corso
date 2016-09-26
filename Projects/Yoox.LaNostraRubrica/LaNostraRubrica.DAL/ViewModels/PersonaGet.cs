using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL.ViewModels
{
    public class PersonaGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int GruppoId { get; set; }
        public string GruppoNome { get; set; }

        static PersonaGet()
        {
            TinyMapper.Bind<Persona, PersonaGet>();
        }
    }
}
