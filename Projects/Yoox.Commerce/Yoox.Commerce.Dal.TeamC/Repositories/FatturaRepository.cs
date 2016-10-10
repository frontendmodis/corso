using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamC.Repositories
{
    public class FatturaRepository : IDisposable
    {
        TeamCDBContext db = new TeamCDBContext();

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
