namespace Yoox.Commerce.Dal.TeamA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrutturaIniziale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TeamA.Carrelli",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataCreazione = c.DateTime(nullable: false),
                        DataUltimaModifica = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TeamA.Clienti", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "TeamA.Clienti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Cognome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TeamA.RigheCarrello",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdottoId = c.Int(nullable: false),
                        Quantita = c.Int(nullable: false),
                        Carrello_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TeamA.Carrelli", t => t.Carrello_Id, cascadeDelete: true)
                .Index(t => t.Carrello_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TeamA.RigheCarrello", "Carrello_Id", "TeamA.Carrelli");
            DropForeignKey("TeamA.Carrelli", "Id", "TeamA.Clienti");
            DropIndex("TeamA.RigheCarrello", new[] { "Carrello_Id" });
            DropIndex("TeamA.Carrelli", new[] { "Id" });
            DropTable("TeamA.RigheCarrello");
            DropTable("TeamA.Clienti");
            DropTable("TeamA.Carrelli");
        }
    }
}
