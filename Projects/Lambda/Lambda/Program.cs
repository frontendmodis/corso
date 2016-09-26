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
            lavoro.Fai();
            Console.WriteLine("...fine lavoro.");
            Console.ReadLine();
        }
    }
}
