using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaNostraRubrica.Web.Models
{
    public class HomeIndexVM
    {
        public IEnumerable<HomeIndexGruppoVM> Gruppi { get; set; } 

        public IEnumerable<HomeIndexPersonaVM> Persone { get; set; }

        public string Query { get; set; }

        public int? Gruppo_Id { get; set; }

        public HomeIndexVM()
        {
            this.Gruppi = new List<HomeIndexGruppoVM>();
            this.Persone = new List<HomeIndexPersonaVM>();
        }
    }

    public class HomeIndexGruppoVM
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
    }

    public class HomeIndexPersonaVM
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string RecapitoPrincipale { get; set; }

    }


}