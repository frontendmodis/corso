using LaNostraRubrica.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL
{
    public class PersoneRepository : BaseRepository
    {
        public IEnumerable<PersonaGet> Get()
        {
            var risultato = this.db.Persone.Include("Gruppo")
                .OrderBy(p => p.Cognome).ThenBy(p => p.Nome);

            return risultato.Select(p => new PersonaGet
            {
                Id = p.Id,
                Nome = p.Nome,
                Cognome = p.Cognome,
                GruppoId = p.Gruppo != null ? p.Gruppo.Id : 0,
                GruppoNome = p.Gruppo != null ? p.Gruppo.Nome : ""
            });
        }

        public PersonaGet Get(int id)
        {
            var risultato = this.db.Persone.Include("Gruppo").First(p => p.Id == id);

            return new PersonaGet
            {
                Id = risultato.Id,
                Nome = risultato.Nome,
                Cognome = risultato.Cognome,
                GruppoId = risultato.Gruppo != null ? risultato.Gruppo.Id : 0,
                GruppoNome = risultato.Gruppo != null ? risultato.Gruppo.Nome : ""
            };
        }

        public int Add(string nome, string cognome)
        {
            var persona = new Persona();
            persona.Nome = nome;
            persona.Cognome = cognome;

            this.db.Persone.Add(persona);
            this.db.SaveChanges();

            return persona.Id;
        }

        public void Update(int id, string nome, string cognome)
        {
            var persona = this.db.Persone.Find(id);
            persona.Nome = nome;
            persona.Cognome = cognome;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = this.db.Persone.Find(id);
            this.db.Persone.Remove(persona);
            this.db.SaveChanges();
        }
    }
}
