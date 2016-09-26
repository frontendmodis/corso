using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL
{
    public class BaseRepository : IDisposable
    {
        protected readonly RubricaDb db = new RubricaDb();

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
