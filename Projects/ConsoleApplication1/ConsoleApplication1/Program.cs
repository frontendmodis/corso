using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pippo = "Ciao Mondo";
            Console.WriteLine(pippo);

            int a = 10;
            int b = 5;
            int c = 3;

            decimal risultato;

            // Aritmetiche
            risultato = a * b;
            Console.WriteLine("a * b = " + risultato);
            risultato = a + b;
            Console.WriteLine("a + b = " + risultato);
            risultato = a - b;
            Console.WriteLine("a - b = " + risultato);
            risultato = a / b;
            Console.WriteLine("a / b = " + risultato);
            risultato = a / c;
            Console.WriteLine("a / c = " + risultato);
            risultato = a % c;
            Console.WriteLine("a % c = " + risultato);

            // Assegnamento
            risultato = a;
            Console.WriteLine("a = " + risultato);
            risultato += b; // risultato = risultato + b; -> risultato = a + b;
            Console.WriteLine("a + b = " + risultato);
            risultato -= b; // risultato = risultato - b; -> risultato = a + b - b;
            Console.WriteLine("a = " + risultato);
            risultato *= b; // risultato = risultato * b -> risultato = a * b
            Console.WriteLine("a * b = " + risultato);
            risultato /= b; // risultato = risultato / b -> risultato = a
            Console.WriteLine("a = " + risultato);

            // Incremento e decremento
            a++; // a = a + 1 -> a += 1
            Console.WriteLine("a++ = " + a);
            ++a; // a = a + 1 -> a += 1
            Console.WriteLine("++a = " + a);
            a--; // a = a - 1 -> a -= 1
            Console.WriteLine("a-- = " + a);
            --a; // a = a - 1 -> a -= 1
            Console.WriteLine("--a = " + a);

            // a = 10
            risultato = a++;
            //risultato = ++a;
            Console.WriteLine("Risultato = " + risultato);
            Console.WriteLine("a = " + a);

            // Confronto
            bool confronto = a == b;
            Console.WriteLine("a == b:" + confronto);
            confronto = a != b;
            Console.WriteLine("a != b:" + confronto);
            confronto = a > b;
            Console.WriteLine("a > b:" + confronto);
            confronto = a >= b;
            Console.WriteLine("a >= b:" + confronto);
            confronto = a < b;
            Console.WriteLine("a < b:" + confronto);
            confronto = a <= b;
            Console.WriteLine("a <= b:" + confronto);

            confronto = a.GetType() == typeof(int);
            Console.WriteLine("typeof a è intero? " + confronto);


            object l = a;
            confronto = l is int;

            Console.WriteLine("a è intero? " + confronto);
            Console.WriteLine("l.GetType:" + l.GetType());

            // Operatori logici
            confronto = true && true; // true
            confronto = true && false; // false
            confronto = false && true; // false
            confronto = false && false; // false

            confronto = true || true; // true
            confronto = true || false; // true
            confronto = false || true; // true
            confronto = false || false; // false

            a = 0;
            confronto = false && (++a == 1);
            Console.WriteLine("a vale:" + a);

            confronto = (++a == 1) && false;
            Console.WriteLine("a vale:" + a);

            confronto = true || (++a == 2);
            Console.WriteLine("a vale:" + a);

            string positivo = a >= 0 ? "Si" : "No";

            Console.WriteLine(positivo);

            risultato = 0.56m;

            a = (int)risultato;
            Console.WriteLine("a vale:" + a);

            a = Convert.ToInt32(risultato);
            Console.WriteLine("a vale:" + a);

            string numero = "1234a";
            //a = Convert.ToInt32(numero);

            bool result = int.TryParse(numero, out a);
            Console.WriteLine("La conversione è riuscita:" + result);
            Console.WriteLine("a vale:" + a);

            Console.ReadLine();
        }
    }
}
