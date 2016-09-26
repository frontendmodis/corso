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
                new Scarpe { Id = 1, Colore = "Rosso",  Marca="Cinti",      Tipo = Tipo.Stivali,   Prezzo = 130m },
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

            risultato = scarpe.Where(s => s.Prezzo > 500 && s.Tipo == Tipo.Decollete);

            foreach (var s in risultato)
            {
                Console.WriteLine("La scarpa {0} è una decollete che costa più di 500 euro.", s.Id);
            }

            // Se non la trova va in errore
            var scarpa = scarpe.First(s => s.Id == 1);

            // Se non la trova da null
            scarpa = scarpe.FirstOrDefault(s => s.Id == 20);

            // Va in errore se la quantità è diversa da 1
            scarpa = scarpe.Single(s => s.Id == 1);

            // Va in errore se la quantità è maggiore di 1
            scarpa = scarpe.SingleOrDefault(s => s.Id == 1);

            // Concatenazione
            scarpa = scarpe
                .Where(s => s.Prezzo > 100)
                .FirstOrDefault(s => s.Colore == "Rosso");

            // Prime 3 scarpe
            risultato = scarpe.Take(3);

            // Prime 4 dopo aver saltalto la prima
            risultato = scarpe.Skip(1).Take(4);

            // Ordinamento
            risultato = scarpe
                .OrderBy(s => s.Prezzo)
                .ThenBy(s => s.Colore)
                .ThenByDescending(s => s.Id);

            var valoreTotale = scarpe.Sum(s => s.Prezzo);

            var colori = scarpe.Select(s => s.Colore).Distinct().OrderBy(c => c);

            risultato = scarpe.Where(s => s.Disponibilità.Any(d => d.Quantità > 0 && d.Taglia == 37));
            Console.ReadLine();
        }
    }
}
