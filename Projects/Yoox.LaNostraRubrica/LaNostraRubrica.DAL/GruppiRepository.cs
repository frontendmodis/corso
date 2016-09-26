using LaNostraRubrica.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL
{
    public class GruppiRepository : BaseRepository
    {
        public IEnumerable<GruppoGet> Get()
        {
            var risultato = this.db.Gruppi.OrderBy(g => g.Nome);
            return risultato.Select(g => new GruppoGet {
                Id = g.Id,
                Nome = g.Nome
            });
        }

        public GruppoGet Get(int id)
        {
            var risultato = this.db.Gruppi.Find(id);
            return new GruppoGet
            {
                Id = risultato.Id,
                Nome = risultato.Nome
            };
        }

        public int Add(string nome)
        {
            var gruppo = new Gruppo();
            gruppo.Nome = nome;
            this.db.Gruppi.Add(gruppo);
            this.db.SaveChanges();

            return gruppo.Id;
        }

        public void Update(int gruppoId, string nome)
        {
            var gruppo = this.db.Gruppi.Find(gruppoId);
            gruppo.Nome = nome;
            this.db.SaveChanges();
        }

        public void Delete(int gruppoId)
        {
            var gruppo = this.db.Gruppi.Find(gruppoId);
            this.db.Gruppi.Remove(gruppo);
            this.db.SaveChanges();
        }
    }
}
