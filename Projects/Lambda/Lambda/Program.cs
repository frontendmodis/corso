using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var lavoro = new FaccioUnGrossoLavoro();

            Console.WriteLine("Inizio lavoro...");
            //lavoro.Fai(new FaccioUnGrossoLavoro.Avanzamento(Scrivo));
            //lavoro.Fai(Scrivo);
            lavoro.Fai(delegate (decimal p)
            {
                Console.Write("\r{0}%   ", p);
            });

            Console.WriteLine("\n...fine lavoro.");
            Console.ReadLine();
        }

        //static void Scrivo(decimal p)
        //{
        //    Console.Write("\r{0}%   ", p);
        //}
    }
}
