namespace Pizzeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ordini",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        Confermato = c.Boolean(),
                        Evaso = c.Boolean(),
                        IdUtente = c.Int(nullable: false),
                        IdPizza = c.Int(nullable: false),
                        Note = c.String(),
                        Quantita = c.Decimal(precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.Pizze", t => t.IdPizza)
                .ForeignKey("dbo.Utenti", t => t.IdUtente)
                .Index(t => t.IdUtente)
                .Index(t => t.IdPizza);
            
            CreateTable(
                "dbo.Pizze",
                c => new
                    {
                        IdPizza = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 16),
                        UrlImg = c.String(),
                        Prezzo = c.Decimal(nullable: false, storeType: "money"),
                        Descrizione = c.String(nullable: false),
                        TempoPreparazione = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPizza);
            
            CreateTable(
                "dbo.Utenti",
                c => new
                    {
                        IdUtente = c.Int(nullable: false, identity: true),
                        Indirizzo = c.String(maxLength: 16),
                        Nome = c.String(maxLength: 16),
                        Cognome = c.String(maxLength: 16),
                        Username = c.String(nullable: false, maxLength: 16),
                        Password_ = c.String(nullable: false, maxLength: 16),
                        IdRuolo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUtente)
                .ForeignKey("dbo.Ruoli", t => t.IdRuolo)
                .Index(t => t.IdRuolo);
            
            CreateTable(
                "dbo.Ruoli",
                c => new
                    {
                        IdRuolo = c.Int(nullable: false, identity: true),
                        User_Admin = c.String(nullable: false, maxLength: 16),
                    })
                .PrimaryKey(t => t.IdRuolo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utenti", "IdRuolo", "dbo.Ruoli");
            DropForeignKey("dbo.Ordini", "IdUtente", "dbo.Utenti");
            DropForeignKey("dbo.Ordini", "IdPizza", "dbo.Pizze");
            DropIndex("dbo.Utenti", new[] { "IdRuolo" });
            DropIndex("dbo.Ordini", new[] { "IdPizza" });
            DropIndex("dbo.Ordini", new[] { "IdUtente" });
            DropTable("dbo.Ruoli");
            DropTable("dbo.Utenti");
            DropTable("dbo.Pizze");
            DropTable("dbo.Ordini");
        }
    }
}
