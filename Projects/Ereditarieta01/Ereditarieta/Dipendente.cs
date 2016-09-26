using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    class Dipendente
    {
        //public string Nome { get; set; }
        //public string Cognome { get; set; }
        //public string Matricola { get; set; }

        public readonly string Nome;
        public readonly string Cognome;
        public string Matricola { get; private set; }

        public Dipendente(string nome, string cognome) : this(nome, cognome, null)
        {
            //this.Nome = nome;
            //this.Cognome = cognome;
            //this.SetMatricola(null);
        }

        public Dipendente(string nome, string cognome, string matricola)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.SetMatricola(matricola);
            //this.Matricola = matricola;
        }

        public void SetMatricola(string matricola)
        {
            if(matricola != null && matricola.Trim().Length == 0)
            {
                throw new Exception("La matricola non va bene");
            } 

            this.Matricola = matricola;
        }

        public virtual void Lavora()
        {
            Console.WriteLine("Che fatica...");
        }
    }
}
