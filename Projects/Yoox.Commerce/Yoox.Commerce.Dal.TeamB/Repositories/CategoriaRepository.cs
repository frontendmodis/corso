using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoox.Commerce.Dal.TeamB.DTOs;

namespace Yoox.Commerce.Dal.TeamB.Repositories
{
    public class CategoriaRepository : IDisposable
    {
        TeamBDBContext db = new TeamBDBContext();

        public IEnumerable<CategoriaDTOGet> Get()
        {
            var categorie = this.db.Categorie.Include("Prodotti").OrderBy(c => c.Nome);
            return TinyMapper.Map<List<CategoriaDTOGet>>(categorie);
        }

        public int Add(CategoriaDTOAdd nuova)
        {
            var categoria = TinyMapper.Map<Categoria>(nuova);
            this.db.Categorie.Add(categoria);
            this.db.SaveChanges();

            return categoria.Id;
        }

        public void Delete(int categoriaId)
        {
            var categoria = this.db.Categorie.Find(categoriaId);
            this.db.Categorie.Remove(categoria);
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
