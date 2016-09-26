using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    class Program01
    {
        // Versione con Array
        // Soluzione 01
        static void Ex01Main(string[] args)
        {
            int[] pippo = new int[5];

            pippo[4] = 1;
            pippo[0] = 5;
            pippo[1] = 4;
            pippo[2] = 3;
            pippo[3] = 2;

            for(int i = 0; i < pippo.Length; i++)
            {
                //Console.WriteLine("Posizione " + i + ": " + pippo[i]);
                Console.WriteLine("Posizione {0}: {1}", i, pippo[i]);
            }

            Array.Sort(pippo);

            //for (int i = 0; i < pippo.Length; i++)
            //{
            //    int p = pippo[i];
            //    Console.WriteLine("Valore: {0}", p);
            //}

            foreach (int p in pippo)
            {
                Console.WriteLine("Valore: {0}", p);
            }

            string[] frutta = { "Kiwi", "Arancia", "Fragola", "Mela", "Pera" };

            string[] tmp = new string[frutta.Length + 1];
            frutta.CopyTo(tmp, 0);
            tmp[tmp.Length - 1] = "Banana";
            frutta = tmp;

            Array.Sort(frutta);

            string fruttaOrdinata = "";

            // Soluzione 1
            //foreach(string frutto in frutta)
            //{
            //    fruttaOrdinata += frutto + ", ";
            //}

            // Soluzione 2
            //for(int i = 0; i < frutta.Length; i++)
            //{
            //    fruttaOrdinata += frutta[i];

            //    if(i < frutta.Length - 1)
            //    {
            //        fruttaOrdinata += ", ";
            //    }
            //}

            // Soluzione 3
            //foreach(string frutto in frutta)
            //{
            //    fruttaOrdinata += frutto + ", ";
            //}

            //fruttaOrdinata = fruttaOrdinata.Substring(0, fruttaOrdinata.Length - 2);

            // Soluzione 4
            fruttaOrdinata = string.Join(", ", frutta);

            Console.WriteLine(fruttaOrdinata);

            Console.ReadLine();
        }
    }
}
