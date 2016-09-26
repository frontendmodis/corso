using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaMiaRubrica
{
    class Persona
    {
        public static int TotalePersone { get; set; }

        public readonly string Nome;
        public readonly string Cognome;
        public string Telefono { get; private set; }

        static Persona()
        {
            Persona.TotalePersone = 0;
        }

        public Persona(string nome, string cognome, string telefono)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Telefono = telefono;
            Persona.TotalePersone++;
        }

        public string NomeCompleto
        {
            get
            {
                return this.Nome + " " + this.Cognome + ": " + this.Telefono;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " (" + this.NomeCompleto + ")";
        }
    }
}
