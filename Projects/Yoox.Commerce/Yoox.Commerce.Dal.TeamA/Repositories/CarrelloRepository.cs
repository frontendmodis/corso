using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoox.Commerce.Dal.TeamA.DTOs;

namespace Yoox.Commerce.Dal.TeamA.Repositories
{
    public class CarrelloRepository : IDisposable
    {
        TeamADBContext db = new TeamADBContext();

        public CarrelloDTOGet Get(int clienteId)
        {
            var carrello = this.GetOrCrea(clienteId);

            return TinyMapper.Map<CarrelloDTOGet>(carrello);
        } 

        protected Carrello GetOrCrea(int clienteId)
        {
            var carrello = this.db.Carrelli.Include("Righe").FirstOrDefault(c => c.Cliente.Id == clienteId);

            if (carrello == null)
            {
                carrello = new Carrello();
                carrello.Cliente = this.db.Clienti.Find(clienteId);
                this.db.Carrelli.Add(carrello);
                this.db.SaveChanges();
            }

            return carrello;
        }

        public void AggiungiProdotto(int clienteId, int prodottoId, int quantita = 1)
        {
            var carrello = this.GetOrCrea(clienteId);
            var riga = carrello.Righe.FirstOrDefault(r => r.ProdottoId == prodottoId);
            
            if(riga == null)
            {
                riga = new RigaCarrello() { Carrello = carrello };
                this.db.RigheCarrello.Add(riga);
            }

            riga.ProdottoId = prodottoId;
            riga.Quantita += quantita;
            this.db.SaveChanges();
        }

        public void RimuoviProdotto(int clienteId, int prodottoId)
        {
            var carrello = this.GetOrCrea(clienteId);
            var riga = carrello.Righe.First(r => r.ProdottoId == prodottoId);
            carrello.Righe.Remove(riga);

            this.db.SaveChanges();
        }

        public void CancellaCarrello(int clienteId)
        {
            var carrello = this.db.Carrelli.Include("Righe").First(c => c.Cliente.Id == clienteId);
            this.db.Carrelli.Remove(carrello);
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
