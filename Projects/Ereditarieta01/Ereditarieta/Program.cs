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
            List<Dipendente> dipendenti = new List<Dipendente>();

            ////Manager capo = new Manager();
            //Dipendente capo = new Manager();
            //capo.Cognome = "Rossi";
            //capo.Nome = "Mario";
            //capo.Matricola = "1";
            Dipendente capo = new Manager("Mario", "Rossi", "1");
            dipendenti.Add(capo);

            ////Operaio operaio = new Operaio();
            //Dipendente operaio = new Operaio();
            //operaio.Cognome = "Verdi";
            //operaio.Nome = "Antonio";
            //operaio.Matricola = "2";
            Dipendente operaio = new Operaio("Antonio", "Verdi", "2");
            dipendenti.Add(operaio);

            //capo.Lavora();
            //operaio.Lavora();
            //((Operaio)operaio).Lavora();

            foreach(var d in dipendenti)
            {
                d.Lavora();
                
                if(d is Operaio)
                {
                    Operaio o = (Operaio)d;
                    o.Sciopera();
                }
            }

            Console.ReadLine();
        }
    }
}
