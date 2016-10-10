using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoox.Commerce.Dal.TeamC.DTOs;

namespace Yoox.Commerce.Dal.TeamC.Repositories
{
    public class OrdineRepository : IDisposable
    {
        TeamCDBContext db = new TeamCDBContext();

        public int Crea(OrdineDTOCrea nuovo)
        {
            var ordine = TinyMapper.Map<Ordine>(nuovo);
            this.db.Ordini.Add(ordine);
            this.db.SaveChanges();

            return ordine.Id;
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
