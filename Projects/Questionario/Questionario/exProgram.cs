using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionario
{
    class exProgram
    {
        static void AMain(string[] args)
        {
            Console.WriteLine("Benvenuti in questo questionario!");

            //for (;;)
            //while(true){}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            ////int i = 0;

            ////for (;;)
            ////{
            ////    if(i == 10) break;
            ////    Console.WriteLine(i++);
            ////}

            string nome;

            do
            {
                Console.WriteLine("Come ti chiami?");
                nome = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(nome));


            ////if(nome == null || nome == "")
            //if (String.IsNullOrWhiteSpace(nome))
            //{
            //    Console.WriteLine("Ti saluto maleducato. Alla prossima.");
            //    Console.ReadLine();
            //    return;
            //}

            Console.WriteLine("Ciao " + nome);
            Console.ReadLine();
        }
    }
}
