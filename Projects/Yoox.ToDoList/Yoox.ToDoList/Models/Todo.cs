using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Yoox.ToDoList.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Testo { get; set; }
        public bool Done { get; set; }

        [Required]
        public string UtenteId { get; set; }
        [ForeignKey("UtenteId")]
        public ApplicationUser Utente { get; set; }
    }
}