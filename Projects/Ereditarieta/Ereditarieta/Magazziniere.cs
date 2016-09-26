using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    class Magazziniere : Dipendente, ISciopero
    {
        public Magazziniere(string nome, string cognome) : 
            base(nome, cognome)
        {
        }

        public Magazziniere(string nome, string cognome, string matricola) : 
            base(nome, cognome, matricola)
        {
        }

        public override void Lavora()
        {
            Console.WriteLine("Prendi e sposta!");
        }

        public void Sciopera()
        {
            Console.WriteLine("Mi prendo una pausa!");
        }
    }
}
