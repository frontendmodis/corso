﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    class Operaio : Dipendente
    {
        public Operaio(string nome, string cognome) : 
            base(nome, cognome)
        {
        }

        public Operaio(string nome, string cognome, string matricola) : 
            base(nome, cognome, matricola)
        {
        }

        public override void Lavora()
        {
            Console.WriteLine("Tum Tum Tum");
        }

        public void Sciopera()
        {
            //this.Matricola = "";
            Console.WriteLine("Braccia incrociate!");
        }
    }
}
