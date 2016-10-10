﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.Commerce.Dal.TeamB.DTOs
{
    public class ProdottoDTOGetAll
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public IEnumerable<CategoriaDTOGet> Categorie { get; set; }
    }
}
