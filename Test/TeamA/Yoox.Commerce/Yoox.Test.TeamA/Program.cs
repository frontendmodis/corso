using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoox.DAL.TeamA.Repo;

namespace Yoox.Test.TeamA
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            do
            {
                Console.Clear();
                Console.WriteLine("scegli un' opzione");
                Console.WriteLine("1 Lista Clienti");
                Console.WriteLine("2 Nuovo Cliente");
                Console.WriteLine("3 Cancella Cliente");
                
                Console.WriteLine("3 esci");
                var tasto = Console.ReadKey();
                switch (tasto.KeyChar)
                {
                    case '1':
                        MostraClienti();
                        break;

                    case '2':
                        CreaCliente();
                        break;

                    case '3':
                        run = false;
                        break;


                }
            } while (run);
        }

        static void MostraClienti()
        {
            var clienteInRepo = new ClientiRepository();

            var list = clienteInRepo.Get();
            Console.Clear();
            Console.WriteLine("Lista clienti");
            foreach (var g in list)
            {
                Console.WriteLine("{0}:{1}", g.Id, g.Nome);
            }

            Console.WriteLine("scegli cliente");
            var key = Console.ReadLine();
            int keyInt;
            int.TryParse(key, out keyInt);
            MenuCliente(keyInt);
           
        }
        static void CreaCliente()
        {
            var gr = new ClientiRepository();
            Console.Clear();

            Console.WriteLine("Nome cliente: ");        
            var nome = Console.ReadLine();          

            Console.WriteLine("Nome cognome: ");
            var cognome = Console.ReadLine();

            Console.WriteLine("Email cliente: ");
            var email = Console.ReadLine();

            gr.Add(nome,cognome,email);

            Console.WriteLine("Cliente inserito");
            Console.ReadLine();
        }

        static void MenuCliente(int idCliente)
        {
            bool run = true;
            do
            {
                Console.Clear();
                Console.WriteLine("scegli un' opzione");
                Console.WriteLine("1 Lista prodotti");
                Console.WriteLine("2 Aggiungi prodotto");
                Console.WriteLine("3 Rimuovi prodotto");

                Console.WriteLine("3 esci");
                var tasto = Console.ReadKey();
                switch (tasto.KeyChar)
                {
                    case '1':
                        MostraProdotti(idCliente);
                        break;

                    case '2':
                        CreaCliente();
                        break;

                    case '3':
                        run = false;
                        break;


                }
            } while (run);
        }

        private static void MostraProdotti(int idCliente)
        {
            Console.Clear();
            var prodotti = new ClientiRepository().Get(idCliente).Carrello;
            foreach(var p in prodotti)
            {
                Console.WriteLine("prodotto {0}",p);
            }
        }
    }
}
