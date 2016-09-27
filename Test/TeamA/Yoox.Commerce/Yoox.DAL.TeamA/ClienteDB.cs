namespace Yoox.DAL.TeamA
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ClienteDB : DbContext
    {
        // Your context has been configured to use a 'ClienteDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Yoox.DAL.TeamA.ClienteDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ClienteDB' 
        // connection string in the application configuration file.
        public ClienteDB()
            : base("name=ClienteDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Cliente> Clienti { get; set; }
        public virtual DbSet<Prodotto> Prodotti { get; set; }
        public virtual DbSet<Carrello> Carrelli { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}