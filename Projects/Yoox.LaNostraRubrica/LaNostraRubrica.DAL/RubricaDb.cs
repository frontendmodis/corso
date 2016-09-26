namespace LaNostraRubrica.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RubricaDb : DbContext
    {
        public RubricaDb()
            : base("name=RubricaDbConnectionString")
        {
        }

        public virtual DbSet<Gruppo> Gruppi { get; set; }
        public virtual DbSet<Persona> Persone { get; set; }
        public virtual DbSet<Recapito> Recapiti { get; set; }
    }
}