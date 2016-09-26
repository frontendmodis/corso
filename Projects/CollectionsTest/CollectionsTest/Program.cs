using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    class Program
    {
        // Versione con ArrayList
        // Soluzione 02
        static void Main(string[] args)
        {
            ArrayList pippo = new ArrayList();

            //pippo[0] = 5;
            //pippo[1] = 4;
            //pippo[2] = 3;
            //pippo[3] = 2;
            //pippo[4] = 1;

            int indice = pippo.Add(5);
            pippo.Add(4);
            pippo.Add(3);
            pippo.Add(2);
            pippo.Add(1);

            //pippo.AddRange(new int[]{ 5, 4, 3, 2, 1 });

            for (int i = 0; i < pippo.Count; i++)
            {
                Console.WriteLine("Posizione {0}: {1}", i, pippo[i]);
            }

            pippo.Sort();

            foreach (int p in pippo)
            {
                Console.WriteLine("Valore: {0}", p);
            }

            List<string> frutta = new List<string>();
            //FruttaStore frutta = new FruttaStore();
            //ArrayList frutta = new ArrayList();
            frutta.AddRange(new string[] { "Kiwi", "Arancia", "Fragola", "Mela", "Pera" });
            //frutta.AddRange("Kiwi", "Arancia", "Fragola", "Mela", "Pera");
            frutta.Add("Banana");
            //frutta.Add(true);

            frutta.Sort();

            string fruttaOrdinata = "";
            //fruttaOrdinata = string.Join(", ", (string[])frutta.ToArray(typeof(string)));
            fruttaOrdinata = string.Join(", ", frutta.ToArray());

            Console.WriteLine(fruttaOrdinata);

            Queue coda = new Queue();
            coda.Enqueue("Elemento 1");
            coda.Enqueue("Elemento 2");
            coda.Enqueue("Elemento 3");

            Console.WriteLine("La coda contiene {0} elementi", coda.Count);

            while(coda.Count > 0)
            {
                object elemento = coda.Dequeue();
                Console.WriteLine(elemento);
            }

            Console.WriteLine("La coda contiene {0} elementi", coda.Count);

            Stack stack = new Stack();
            stack.Push("Elemento 1");
            stack.Push("Elemento 2");
            stack.Push("Elemento 3");
            
            Console.WriteLine("Lo stack contiene {0} elementi", stack.Count);

            while (stack.Count > 0)
            {
                object elemento = stack.Pop();
                Console.WriteLine(elemento);
            }

            Console.WriteLine("Lo stack contiene {0} elementi", stack.Count);

            Hashtable studenti = new Hashtable();
            //studenti.Add("Villani", "Silvia Villani");
            //studenti.Add("Simeti", "Rosario Simeti");
            //studenti.Add("Nardi", "Filippo Nardi");
            //studenti.Add("Falbo", "Giovanni Falbo");
            Studente studente = new Studente();
            studente.nome = "Silvia";
            studente.cognome = "Villani";
            studenti.Add("Villani", studente);

            studente = new Studente();
            studente.nome = "Rosario";
            studente.cognome = "Simeti";
            studenti.Add("Simeti", studente);

            studente = new Studente();
            studente.nome = "Filippo";
            studente.cognome = "Nardi";
            studenti.Add("Nardi", studente);

            studente = new Studente();
            studente.nome = "Giovanni";
            studente.cognome = "Falbo";
            studenti.Add("Falbo", studente);

            Studente nardi = (Studente)studenti["Nardi"];
            Console.WriteLine(nardi.nome + " " + nardi.cognome);

            Console.ReadLine();
        }
    }
}
