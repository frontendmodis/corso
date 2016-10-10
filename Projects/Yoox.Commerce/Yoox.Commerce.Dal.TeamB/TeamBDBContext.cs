namespace Yoox.Commerce.Dal.TeamB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBDBContext : DbContext
    {
        public TeamBDBContext()
            : base("name=TeamBDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TeamB");
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Categoria>().HasMany(c => c.Prodotti)
                                    .WithMany(p => p.Categorie)
                                    .Map(m => m.ToTable("CategorieProdotti", "TeamB"));
        }

        public virtual DbSet<Categoria> Categorie { get; set; }
        public virtual DbSet<Prodotto> Prodotti { get; set; }
    }
}