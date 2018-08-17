namespace BlackJack.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Suit = c.String(),
                        Rank = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlayerType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                        CurrentRound = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerCards", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerCards", "CardId", "dbo.Cards");
            DropIndex("dbo.PlayerCards", new[] { "CardId" });
            DropIndex("dbo.PlayerCards", new[] { "PlayerId" });
            DropTable("dbo.PlayerCards");
            DropTable("dbo.Players");
            DropTable("dbo.Cards");
        }
    }
}
