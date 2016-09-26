using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Snake
{
    class Snake
    {
        private readonly char Carattere;
        public readonly Posizione PosizioneIniziale;
        public Posizione PosizioneFinale { get; private set; }
        private Direzione? UltimaDirezione = null;

        public Snake(Posizione posizioneIniziale) : this(posizioneIniziale, '+')
        {
        }

        public Snake(Posizione posizioneIniziale, char carattere)
        {
            this.PosizioneIniziale = posizioneIniziale;
            this.PosizioneFinale = this.PosizioneIniziale;

            this.Carattere = carattere;

            Console.SetCursorPosition(
                this.PosizioneIniziale.Orizzontale, 
                this.PosizioneIniziale.Verticale
            );

            Console.Write(this.Carattere);
        }

        public void Muoviti(Direzione? d)
        {

            d = d ?? this.UltimaDirezione;
            //d = (d == null) ? this.UltimaDirezione : d;
            if (d == null) return;

            //if(d == null)
            //{
            //    if(this.UltimaDirezione != null)
            //    {
            //        d = this.UltimaDirezione;
            //    } else
            //    {
            //        return;
            //    }
            //}


            if(VerificaDirezione.SonoOpposte(this.UltimaDirezione, d))
            {
                d = this.UltimaDirezione;
            }

            //if(this.UltimaDirezione != null)
            //{
            //    if((this.UltimaDirezione.Value == Direzione.Su
            //    && d.Value == Direzione.Giu)
            //    || (this.UltimaDirezione.Value == Direzione.Giu
            //    && d.Value == Direzione.Su)
            //    || (this.UltimaDirezione.Value == Direzione.Destra
            //    && d.Value == Direzione.Sinistra)
            //    || (this.UltimaDirezione.Value == Direzione.Sinistra
            //    && d.Value == Direzione.Destra))
            //    {
            //        d = this.UltimaDirezione;
            //    }
            //}

            this.UltimaDirezione = d;

            // Muoviti
            switch (d.Value)
            {
                case Direzione.Su:
                    this.PosizioneFinale = new Posizione(
                        this.PosizioneFinale.Orizzontale, 
                        this.PosizioneFinale.Verticale - 1);
                    break;
                case Direzione.Destra:
                    this.PosizioneFinale = new Posizione(
                        this.PosizioneFinale.Orizzontale + 1,
                        this.PosizioneFinale.Verticale);
                    break;
                case Direzione.Giu:
                    this.PosizioneFinale = new Posizione(
                        this.PosizioneFinale.Orizzontale,
                        this.PosizioneFinale.Verticale + 1);
                    break;
                case Direzione.Sinistra:
                    this.PosizioneFinale = new Posizione(
                        this.PosizioneFinale.Orizzontale - 1,
                        this.PosizioneFinale.Verticale);
                    break;
            }

            Console.SetCursorPosition(
                this.PosizioneFinale.Orizzontale,
                this.PosizioneFinale.Verticale);

            Console.Write(this.Carattere);
        }
    }
}
