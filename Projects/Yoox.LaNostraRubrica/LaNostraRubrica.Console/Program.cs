using LaNostraRubrica.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Clear();
                Console.WriteLine("Ciao, scegli un'opzione:");
                Console.WriteLine("1 Lista Gruppi");
                Console.WriteLine("2 Nuovo Gruppo");
                Console.WriteLine("3 Esci");

                var tasto = Console.ReadKey();

                switch (tasto.KeyChar)
                {
                    case '1':
                        Program.MostraGruppi();
                        break;
                    case '2':
                        Program.CreaGruppo();
                        break;
                    case '3':
                        return;
                }
            }
        }
        static void MostraGruppi()
        {
            var gr = new GruppiRepository();
            var listaGruppi = gr.Get();
            Console.Clear();
            Console.WriteLine("Ecco l'elenco dei gruppi:");
            foreach(var gruppo in listaGruppi)
            {
                Console.WriteLine("{0}: {1}", gruppo.Id, gruppo.Nome);
            }
            Console.WriteLine("Premi Invio per tornare al menu");
            Console.ReadLine();
        }

        static void CreaGruppo()
        {
            var gr = new GruppiRepository();

            Console.Clear();
            Console.WriteLine("Come si chiama il gruppo?");
            var nomeGruppo = Console.ReadLine();

            gr.Add(nomeGruppo);
            Console.WriteLine("Gruppo Inserito, premi invio per tornare al menu");
            Console.ReadLine();
        }
    }
}
