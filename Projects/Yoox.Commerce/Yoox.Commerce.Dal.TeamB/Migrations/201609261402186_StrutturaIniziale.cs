namespace Yoox.Commerce.Dal.TeamB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrutturaIniziale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TeamB.Categorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TeamB.Prodotti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TeamB.CategorieProdotti",
                c => new
                    {
                        Categoria_Id = c.Int(nullable: false),
                        Prodotto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categoria_Id, t.Prodotto_Id })
                .ForeignKey("TeamB.Categorie", t => t.Categoria_Id, cascadeDelete: true)
                .ForeignKey("TeamB.Prodotti", t => t.Prodotto_Id, cascadeDelete: true)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Prodotto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TeamB.CategorieProdotti", "Prodotto_Id", "TeamB.Prodotti");
            DropForeignKey("TeamB.CategorieProdotti", "Categoria_Id", "TeamB.Categorie");
            DropIndex("TeamB.CategorieProdotti", new[] { "Prodotto_Id" });
            DropIndex("TeamB.CategorieProdotti", new[] { "Categoria_Id" });
            DropTable("TeamB.CategorieProdotti");
            DropTable("TeamB.Prodotti");
            DropTable("TeamB.Categorie");
        }
    }
}
