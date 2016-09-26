using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<Dipendente> dipendenti = new List<Dipendente>()
            var dipendenti = new List<Dipendente>()
            {
                //new Dipendente("Pinco", "Pallino", "0"),
                new Manager("Mario", "Rossi", "1"),
                new Operaio("Antonio", "Verdi", "2"),
                new Magazziniere("Maria", "Bianchi", "3")
            };

            //foreach(Dipendente d in dipendenti)
            foreach (var d in dipendenti)
            {
                d.Lavora();

                if (d is ISciopero)
                {
                    //ISciopero s = (ISciopero)d;
                    var s = (ISciopero)d;
                    s.Sciopera();
                }

                //if(d is Operaio)
                //{
                //    Operaio o = (Operaio)d;
                //    o.Sciopera();
                //}

                //if(d is Magazziniere)
                //{
                //    Magazziniere m = (Magazziniere)d;
                //    m.Sciopera();
                //}
            }

            Console.ReadLine();
        }
    }
}
