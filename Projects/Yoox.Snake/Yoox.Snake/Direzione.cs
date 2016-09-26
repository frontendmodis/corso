using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Snake
{
    enum Direzione
    {
        Su, Destra, Giu, Sinistra
    }

    static class VerificaDirezione
    {
        public static bool SonoOpposte(Direzione? a, Direzione? b)
        {
            if (a != null && b != null)
            {
                switch (a.Value)
                {
                    case Direzione.Su:
                        return b.Value == Direzione.Giu;
                    case Direzione.Destra:
                        return b.Value == Direzione.Sinistra;
                    case Direzione.Giu:
                        return b.Value == Direzione.Su;
                    case Direzione.Sinistra:
                        return b.Value == Direzione.Destra;
                }
            }

            return false;
        }
    }
}
