using LaNostraRubrica.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;

namespace LaNostraRubrica.DAL
{
    public class PersoneRepository : BaseRepository
    {
        public IEnumerable<PersonaGet> Get(int? gruppoId = null, string ricerca = null)
        {
            //List<Persona> risultato = null;

            //if (gruppoId == null)
            //{
            //    risultato = this.db.Persone.Include("Gruppo")
            //        .OrderBy(p => p.Cognome).ThenBy(p => p.Nome).ToList();

            //} else
            //{
            //    risultato = this.db.Persone.Include("Gruppo")
            //        .Where(p => p.Gruppo_Id == gruppoId.Value)
            //        .OrderBy(p => p.Cognome).ThenBy(p => p.Nome).ToList();
            //}

            var risultato = this.db.Persone.Include("Gruppo").Include("Recapiti")
                .Where(p => gruppoId == null || p.Gruppo_Id == gruppoId.Value)
                .Where(p => ricerca == null || p.Nome.Contains(ricerca) || p.Cognome.Contains(ricerca))
                .OrderBy(p => p.Cognome).ThenBy(p => p.Nome);

            //return TinyMapper.Map<List<PersonaGet>>(risultato);

            return risultato.Select(p => new PersonaGet
            {
                Id = p.Id,
                Nome = p.Nome,
                Cognome = p.Cognome,
                GruppoId = p.Gruppo != null ? p.Gruppo.Id : 0,
                GruppoNome = p.Gruppo != null ? p.Gruppo.Nome : "",
                RecapitoPrincipale = p.Recapiti.Count() >= 0 ? p.Recapiti.FirstOrDefault().Valore : ""
            }).ToList();
        }

        public PersonaGet Get(int id)
        {
            var risultato = this.db.Persone.Include("Gruppo").First(p => p.Id == id);

            return TinyMapper.Map<PersonaGet>(risultato);
            //return new PersonaGet
            //{
            //    Id = risultato.Id,
            //    Nome = risultato.Nome,
            //    Cognome = risultato.Cognome,
            //    GruppoId = risultato.Gruppo != null ? risultato.Gruppo.Id : 0,
            //    GruppoNome = risultato.Gruppo != null ? risultato.Gruppo.Nome : ""
            //};
        }

        public IEnumerable<PersonaGet> GetConEmail()
        {
            var risultato = this.db.Persone
                .Where(p => p.Recapiti.Any(r => r.Tipo == TipoRecapito.Email))
                .OrderBy(p => p.Cognome).ThenBy(p => p.Nome).ToList();

            return TinyMapper.Map<List<PersonaGet>>(risultato);

            //return risultato.Select(p => new PersonaGet {
            //    Id = p.Id,
            //    Nome = p.Nome,
            //    Cognome = p.Cognome,
            //    GruppoId = p.Gruppo != null ? p.Gruppo.Id : 0,
            //    GruppoNome = p.Gruppo != null ? p.Gruppo.Nome : ""
            //});
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
