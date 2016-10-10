namespace Yoox.Commerce.Dal.TeamA
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamADBContext : DbContext
    {
        public TeamADBContext()
            : base("name=TeamADBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TeamA");
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Cliente> Clienti { get; set; }
        public virtual DbSet<Carrello> Carrelli { get; set; }
        public virtual DbSet<RigaCarrello> RigheCarrello { get; set; }

    }
}