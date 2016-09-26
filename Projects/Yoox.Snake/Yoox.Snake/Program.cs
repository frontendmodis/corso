using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var campo = new Campo(Console.WindowWidth, Console.WindowHeight);
            campo.Disegna();

            var snake = new Snake(new Posizione(1, 1));

            bool continua = true;

            while (continua)
            {
                var cicli = 0;

                while (!Console.KeyAvailable && cicli < 6)
                {
                    System.Threading.Thread.Sleep(10);
                    cicli++;                   
                }

                if (Console.KeyAvailable)
                {
                    var k = Console.ReadKey(true);

                    switch (k.Key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.Muoviti(Direzione.Su);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Muoviti(Direzione.Destra);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Muoviti(Direzione.Giu);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Muoviti(Direzione.Sinistra);
                            break;
                        default:
                            snake.Muoviti(null);
                            break;
                    }
                }
                else
                {
                    snake.Muoviti(null);
                }
            }

            Console.ReadLine();
        }
    }
}
