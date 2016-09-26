using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    class Manager : Dipendente
    {
        public Manager(string nome, string cognome) : 
            base(nome, cognome)
        {
        }

        public Manager(string nome, string cognome, string matricola) : 
            base(nome, cognome, matricola)
        {
        }
        
        public override void Lavora()
        {
            Console.WriteLine("Vediamo cosa succede su facebook...");
            //base.Lavora();
        }
    }
}
