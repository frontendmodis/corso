using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionario
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            Persona utente = new Persona();
            Console.WriteLine("Benvenuti in questo questionario!");

            do
            {
                Console.WriteLine("Come ti chiami?");
                nome = Console.ReadLine();
            }
            while (!utente.TrySetNome(nome));

            Console.WriteLine("Ciao " + utente.nome);

            string anno;

            do
            {
                Console.WriteLine("In che anno sei nat*?");
                anno = Console.ReadLine();
            }
            while (!utente.TrySetAnno(anno));

            Console.WriteLine("Sei nell'anno dei " + utente.Eta());

            switch (utente.FasciaEta())
            {
                case 0:
                    Console.WriteLine("Fenomeno!");
                    break;
                case 1:
                    Console.WriteLine("Ti saluto poppante");
                    break;
                case 2:
                    Console.WriteLine("Bella vita!");
                    break;
                case 3:
                    Console.WriteLine("Li senti i primi acciacchi è!");
                    break;
                default:
                    Console.WriteLine("In pensione!!");
                    break;
            }

            Console.WriteLine("Attendere prego, elaborazione in corso.");

            for(int i = 1; i <= 2016; i++)
            {
                int perc = Convert.ToInt32((i * 100m) / 2016);
                Console.Write("\r{0}%", perc);
                System.Threading.Thread.Sleep(10);
            }

            switch (utente.FasciaEta())
            {
                case 0:
                case 1:
                case 4:
                    Console.WriteLine("Continuiamo con il questionario...");
                    break;
                case 2:
                    Console.WriteLine("Andiamo a comandare!");
                    break;
                default:
                    Console.WriteLine("Mojito!!");
                    break;
            }

            //DateTime data = new DateTime(annoNascita, 1, 1);

            if (DateTime.IsLeapYear(utente.annoNascita))
            {
                Console.WriteLine("Ma lo sai che sei nat* in un anno bisestile?");
            }

            DateTime natale = new DateTime(utente.annoNascita, 12, 25);

            Console.WriteLine("Quando sei nat* Natale cadeva di " + natale.ToString("dddd"));

            Console.WriteLine("Ok, ora basta con gli scherzi. Facciamo sul serio.");
            Console.WriteLine("Quiz C#");

            Console.WriteLine("Variabili");
            Console.WriteLine("1. Quali elementi caratterizzano una variabile?");
            Console.WriteLine("A. Tipo, Nome, Valore, Scope, Lifetime, indirizzo");
            Console.WriteLine("B. Tipo, Nome, Valore");
            Console.WriteLine("C. Scope, Lifetime, Indirizzo");
            Console.WriteLine("D. Varianza e covarianza");
            utente.risposte[0] = Console.ReadLine();

            Console.WriteLine("Tipi di dati");
            Console.WriteLine("2. Quali sono tipi di dati validi in c#?");
            Console.WriteLine("A. int, short, string");
            Console.WriteLine("B. object, decimal, float");
            Console.WriteLine("C. Persona, Azienda, Cliente");
            Console.WriteLine("D. DateTime, bool");
            utente.risposte[1] = Console.ReadLine();

            Console.ReadLine();
        }
    }
}
