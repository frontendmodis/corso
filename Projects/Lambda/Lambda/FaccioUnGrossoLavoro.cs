using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    public class FaccioUnGrossoLavoro
    {
        public void Fai()
        {
            for(var i = 0; i < 1000; i++)
            {
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
