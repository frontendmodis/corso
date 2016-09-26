using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Snake
{
    struct Posizione
    {
        public readonly int Orizzontale;
        public readonly int Verticale;

        public Posizione(int orizzontale, int verticale)
        {
            this.Orizzontale = orizzontale;
            this.Verticale = verticale;
        }
    }
}
