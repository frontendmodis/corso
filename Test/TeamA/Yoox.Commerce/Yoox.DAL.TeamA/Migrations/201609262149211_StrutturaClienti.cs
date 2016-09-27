namespace Yoox.DAL.TeamA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrutturaClienti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TeamA.Clienti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 255),
                        Indirizzo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("TeamA.Clienti");
        }
    }
}
