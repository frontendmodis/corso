﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL
{
    [Table("Gruppi")]
    public class Gruppo
    {
        //[Key()]
        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(4)]
        public string Nome { get; set; }
        public ICollection<Persona> Persone { get; set; } 

        public Gruppo()
        {
            this.Persone = new HashSet<Persona>();
        }
    }
}
