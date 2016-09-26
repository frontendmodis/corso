using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    public class FaccioUnGrossoLavoro
    {
        public delegate void Avanzamento(decimal percentuale);
        public void Fai(Avanzamento log)
        {
            for(var i = 0; i < 1000; i++)
            {
                System.Threading.Thread.Sleep(20);
                log((i + 1) * 0.1m);
            }
        }
    }
}
