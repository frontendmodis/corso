using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL.ViewModels
{
    public class GruppoGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        static GruppoGet()
        {
            TinyMapper.Bind<Gruppo, GruppoGet>();
        }
    }
}
