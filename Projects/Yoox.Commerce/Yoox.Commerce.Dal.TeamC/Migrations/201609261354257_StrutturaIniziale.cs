namespace Yoox.Commerce.Dal.TeamC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrutturaIniziale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TeamC.Fatture",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumeroFattura = c.String(),
                        DataFattura = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TeamC.Ordine", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "TeamC.Ordine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        ClienteNome = c.String(nullable: false, maxLength: 30),
                        ClienteCognome = c.String(nullable: false, maxLength: 30),
                        ClienteIndirizzoSpedizione = c.String(nullable: false, maxLength: 250),
                        ClienteIndirizzoFatturazione = c.String(nullable: false, maxLength: 250),
                        NumeroOrdine = c.String(),
                        DataOrdine = c.DateTime(nullable: false),
                        DataChiusuraOrdine = c.DateTime(),
                        Stato = c.Byte(nullable: false),
                        CostiSpedizione = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TeamC.RigheOrdini",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdottoId = c.Int(nullable: false),
                        QuantitaOrdinata = c.Int(nullable: false),
                        QuantitaEvasa = c.Int(nullable: false),
                        PrezzoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrezzoTotale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ordine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TeamC.Ordine", t => t.Ordine_Id, cascadeDelete: true)
                .Index(t => t.Ordine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TeamC.Fatture", "Id", "TeamC.Ordine");
            DropForeignKey("TeamC.RigheOrdini", "Ordine_Id", "TeamC.Ordine");
            DropIndex("TeamC.RigheOrdini", new[] { "Ordine_Id" });
            DropIndex("TeamC.Fatture", new[] { "Id" });
            DropTable("TeamC.RigheOrdini");
            DropTable("TeamC.Ordine");
            DropTable("TeamC.Fatture");
        }
    }
}
