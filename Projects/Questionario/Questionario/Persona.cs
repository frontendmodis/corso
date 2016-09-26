using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionario
{
    class Persona
    {
        public string nome;
        public short annoNascita;
        //public int eta;
        //public byte fasciaEta;
        public string[] risposte = new string[2];

        public bool TrySetNome(string nome)
        {
            //bool risultato = false;

            //if (!(String.IsNullOrWhiteSpace(nome)))
            //{
            //    this.nome = nome;
            //    risultato = true;
            //}

            //return risultato;

            if (String.IsNullOrWhiteSpace(nome))
            {
                return false;
            }

            this.nome = nome;
            return true;
        }

        public bool TrySetAnno(string anno)
        {
            bool risultato = short.TryParse(anno, out this.annoNascita);

            if (risultato)
            {
                if (this.annoNascita > DateTime.Today.Year)
                {
                    risultato = false;
                }
            }

            return risultato;
        }

        public int Eta()
        {
            return DateTime.Today.Year - this.annoNascita;
        }

        public byte FasciaEta()
        {
            if (this.Eta() <= 4)
            {
                return 0;
            }
            else if (this.Eta() < 18)
            {
                return 1;
            }
            else if (this.Eta() < 30)
            {
                return 2;
            }
            else if (this.Eta() < 40)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
    }
}
