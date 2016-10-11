namespace Yoox.ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiuntiTodo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Testo = c.String(nullable: false, maxLength: 255),
                        Done = c.Boolean(nullable: false),
                        UtenteId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UtenteId, cascadeDelete: true)
                .Index(t => t.UtenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "UtenteId", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "UtenteId" });
            DropTable("dbo.Todoes");
        }
    }
}
