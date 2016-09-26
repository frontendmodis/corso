using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Snake
{
    class Campo
    {
        public readonly int Larghezza;
        public readonly int Altezza;

        public Campo(int larghezza, int altezza)
        {
            this.Larghezza = larghezza;
            this.Altezza = altezza;
        }

        public void Disegna()
        {
            Console.CursorVisible = false;
            Console.Clear();
            this.DisegnaRiga(0);
            this.DisegnaRiga(this.Altezza - 1);

            for (var i = 1; i < this.Altezza - 1; i++)
            {
                this.DisegnaBordo(i);
            }
        }

        private void DisegnaRiga(int posizioneVerticale)
        {
            var riga = new String('-', this.Larghezza);
            Console.SetCursorPosition(0, posizioneVerticale);
            Console.Write(riga);
        }

        private void DisegnaBordo(int posizioneVerticale)
        {
            Console.SetCursorPosition(0, posizioneVerticale);
            Console.Write('|');
            Console.SetCursorPosition(this.Larghezza - 1, posizioneVerticale);
            Console.Write('|');
        }
    }
}
