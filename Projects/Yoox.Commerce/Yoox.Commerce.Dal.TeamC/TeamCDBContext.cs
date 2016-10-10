namespace Yoox.Commerce.Dal.TeamC
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamCDBContext : DbContext
    {
        public TeamCDBContext()
            : base("name=TeamCDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TeamC");
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Fattura> Fatture { get; set; }
        public virtual DbSet<Ordine> Ordini { get; set; }
        public virtual DbSet<RigaOrdine> RigheOrdini { get; set; }

    }
}