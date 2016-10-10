using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoox.Commerce.Dal.TeamA.DTOs;
using Yoox.Commerce.Dal.TeamB.DTOs;

namespace Yoox.Commerce.Dal.TeamB.Repositories
{
    public class ProdottoRepository : IDisposable
    {
        TeamBDBContext db = new TeamBDBContext();

        public IEnumerable<ProdottoDTOGetAll> Get()
        {
            var prodotti = this.db.Prodotti.Include("Categorie").OrderBy(p => p.Nome);
            return TinyMapper.Map<List<ProdottoDTOGetAll>>(prodotti);
        }

        public ProdottoDTOGet Get(int prodottoId)
        {
            var prodotto = this.db.Prodotti.Find(prodottoId);
            return TinyMapper.Map<ProdottoDTOGet>(prodotto);
        }

        public IEnumerable<ProdottoDTOGet> GetPerCategoria(int categoriaId)
        {
            var prodotti = this.db.Prodotti.Where(p => p.Categorie.Any(c => c.Id == categoriaId)).OrderBy(p => p.Nome);
            return TinyMapper.Map<List<ProdottoDTOGet>>(prodotti);
        }

        public int Add(ProdottoDTOAdd nuovo)
        {
            var prodotto = TinyMapper.Map<Prodotto>(nuovo);
            this.db.Prodotti.Add(prodotto);
            this.db.SaveChanges();
            return prodotto.Id;
        }

        public void CambiaPrezzo(int prodottoId, decimal prezzo)
        {
            var prodotto = this.db.Prodotti.Find(prodottoId);
            prodotto.Prezzo = prezzo;
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
