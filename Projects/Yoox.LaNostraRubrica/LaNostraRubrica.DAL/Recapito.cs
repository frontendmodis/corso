using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaNostraRubrica.DAL
{
    [Table("Recapiti")]
    public class Recapito
    {
        //public const byte EMAIL = 0;
        //public const byte TELEFONO = 1;
        //public const byte CELLULARE = 2;

        public int Id { get; set; }

        // 0 - Email, 1 - Telefono, 2 - Cellulare
        //public byte Tipo { get; set; }
        public TipoRecapito Tipo { get; set; }

        [Required, MaxLength(150), MinLength(1)]
        public string Valore { get; set; }
        [Required]
        public Persona Persona { get; set; }
    }

    public enum TipoRecapito : byte
    {
        Email = 0, EmailLavoro = 4, Telefono = 1, Cellulare = 2
    }
}
