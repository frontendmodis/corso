using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public class Scarpe
    {
        public int Id { get; set; }
        public string Colore { get; set; }
        public string Marca { get; set; }
        public decimal Prezzo { get; set; }
        public Tipo Tipo { get; set; }
    }

    public enum Tipo : byte
    {
        Ginnastica, Decollete, Ballerina,
        Stringate, Tacco12, Bikers, Sneakers,
        Sandali, Infradito, Stivali
    }
}
