using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var scarpe = new List<Scarpe>()
            {
                new Scarpe { Id = 1, Colore = "Rosso",  Marca="Cinti",      Tipo = Tipo.Stivali,   Prezzo = 130m  },
                new Scarpe { Id = 2, Colore = "Blu",    Marca="Armani",     Tipo = Tipo.Stringate, Prezzo = 980m  },
                new Scarpe { Id = 3, Colore = "Nero",   Marca="Valentino",  Tipo = Tipo.Infradito, Prezzo = 210m  },
                new Scarpe { Id = 4, Colore = "Beige",  Marca="Balenciaga", Tipo = Tipo.Decollete, Prezzo = 1030m  },
                new Scarpe { Id = 5, Colore = "Giallo", Marca="Armani",     Tipo = Tipo.Sandali,   Prezzo = 581m  }
            };


            //var risultato = scarpe.Where(delegate (Scarpe s)
            //{
            //    var isArmani = false;
            //    isArmani = s.Marca == "Armani";
            //    return isArmani;
            //});

            //var risultato = scarpe.Where(delegate (Scarpe s)
            //{
            //    return s.Marca == "Armani";
            //});

            var risultato = scarpe.Where(s => s.Marca == "Armani");

            foreach(var s in risultato)
            {
                Console.WriteLine("La scarpa {0} è di Armani", s.Id);
            }

            Console.ReadLine();
        }
    }
}
