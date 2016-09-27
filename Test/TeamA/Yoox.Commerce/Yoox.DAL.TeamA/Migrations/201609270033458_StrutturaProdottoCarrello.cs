namespace Yoox.DAL.TeamA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrutturaProdottoCarrello : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TeamA.Carrelli",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TeamA.Prodotti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Carrello_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TeamA.Carrelli", t => t.Carrello_Id)
                .Index(t => t.Carrello_Id);
            
            AddColumn("TeamA.Clienti", "Carrello_Id", c => c.Int());
            CreateIndex("TeamA.Clienti", "Carrello_Id");
            AddForeignKey("TeamA.Clienti", "Carrello_Id", "TeamA.Carrelli", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("TeamA.Clienti", "Carrello_Id", "TeamA.Carrelli");
            DropForeignKey("TeamA.Prodotti", "Carrello_Id", "TeamA.Carrelli");
            DropIndex("TeamA.Clienti", new[] { "Carrello_Id" });
            DropIndex("TeamA.Prodotti", new[] { "Carrello_Id" });
            DropColumn("TeamA.Clienti", "Carrello_Id");
            DropTable("TeamA.Prodotti");
            DropTable("TeamA.Carrelli");
        }
    }
}
