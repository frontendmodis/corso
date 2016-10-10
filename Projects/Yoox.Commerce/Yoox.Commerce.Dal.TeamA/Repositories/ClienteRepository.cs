using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoox.Commerce.Dal.TeamA.DTOs;

namespace Yoox.Commerce.Dal.TeamA.Repositories
{
    public class ClienteRepository : IDisposable
    {
        TeamADBContext db = new TeamADBContext();

        public ClienteDTOGet Get(int id)
        {
            var cliente = this.db.Clienti.Find(id);
            return TinyMapper.Map<ClienteDTOGet>(cliente);
        }

        public int Add(ClienteDTOAdd nuovo)
        {
            var cliente = TinyMapper.Map<Cliente>(nuovo);
            this.db.Clienti.Add(cliente);
            this.db.SaveChanges();

            return cliente.Id;
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
