using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    abstract class Dipendente
    {
        public readonly string Nome;
        public readonly string Cognome;
        public string Matricola { get; private set; }

        public Dipendente(string nome, string cognome) : this(nome, cognome, null)
        {
        }

        public Dipendente(string nome, string cognome, string matricola)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.SetMatricola(matricola);
        }

        public void SetMatricola(string matricola)
        {
            if(matricola != null && matricola.Trim().Length == 0)
            {
                throw new Exception("La matricola non va bene");
            } 

            this.Matricola = matricola;
        }

        public abstract void Lavora();
        //public virtual void Lavora()
        //{
        //    Console.WriteLine("Che fatica...");
        //}
    }
}
