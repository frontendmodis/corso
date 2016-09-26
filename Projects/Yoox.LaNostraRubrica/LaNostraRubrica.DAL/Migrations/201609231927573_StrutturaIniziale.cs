namespace LaNostraRubrica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrutturaIniziale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gruppi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Gruppo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gruppi", t => t.Gruppo_Id)
                .Index(t => t.Gruppo_Id);
            
            CreateTable(
                "dbo.Recapiti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.Byte(nullable: false),
                        Valore = c.String(nullable: false, maxLength: 150),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persone", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recapiti", "Persona_Id", "dbo.Persone");
            DropForeignKey("dbo.Persone", "Gruppo_Id", "dbo.Gruppi");
            DropIndex("dbo.Recapiti", new[] { "Persona_Id" });
            DropIndex("dbo.Persone", new[] { "Gruppo_Id" });
            DropTable("dbo.Recapiti");
            DropTable("dbo.Persone");
            DropTable("dbo.Gruppi");
        }
    }
}
