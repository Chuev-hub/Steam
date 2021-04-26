namespace Steam.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 64),
                        PassHash = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ProfileName = c.String(nullable: false, maxLength: 64),
                        RealName = c.String(maxLength: 64),
                        Country = c.String(maxLength: 128),
                        More = c.String(maxLength: 1024),
                        Avatar = c.Binary(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ChatId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageText = c.String(nullable: false, maxLength: 2048),
                        MessageTime = c.DateTime(nullable: false),
                        SenderId = c.Int(nullable: false),
                        ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Chats", t => t.ChatId)
                .ForeignKey("dbo.Accounts", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ChatId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(nullable: false, maxLength: 128),
                        GameInfo = c.String(),
                        Description = c.String(),
                        HeaderImageURL = c.String(),
                        Requirements = c.String(),
                        RealeaseDate = c.String(),
                        Currency = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Screenshots",
                c => new
                    {
                        ScreenshotId = c.Int(nullable: false, identity: true),
                        ScreenshotURL = c.String(),
                    })
                .PrimaryKey(t => t.ScreenshotId);
            
            CreateTable(
                "dbo.ProfileComments",
                c => new
                    {
                        ProfileCommentId = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        CommentTime = c.DateTime(nullable: false),
                        CommentText = c.String(nullable: false, maxLength: 512),
                    })
                .PrimaryKey(t => t.ProfileCommentId)
                .ForeignKey("dbo.Accounts", t => t.AuthorId)
                .ForeignKey("dbo.Accounts", t => t.ProfileId)
                .Index(t => t.ProfileId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.ChatsInAccounts",
                c => new
                    {
                        ChatId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChatId, t.AccountId })
                .ForeignKey("dbo.Accounts", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Chats", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.ChatId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.DevelopersInGames",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeveloperId, t.GameId })
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.DeveloperId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.GenresInGames",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GenreId, t.GameId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.ScreenshotsInGames",
                c => new
                    {
                        ScreenshotId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScreenshotId, t.GameId })
                .ForeignKey("dbo.Screenshots", t => t.ScreenshotId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.ScreenshotId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.GamesInAccounts",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.AccountId })
                .ForeignKey("dbo.Accounts", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileComments", "ProfileId", "dbo.Accounts");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Accounts");
            DropForeignKey("dbo.ProfileComments", "AuthorId", "dbo.Accounts");
            DropForeignKey("dbo.GamesInAccounts", "AccountId", "dbo.Games");
            DropForeignKey("dbo.GamesInAccounts", "GameId", "dbo.Accounts");
            DropForeignKey("dbo.ScreenshotsInGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.ScreenshotsInGames", "ScreenshotId", "dbo.Screenshots");
            DropForeignKey("dbo.GenresInGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.GenresInGames", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.DevelopersInGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.DevelopersInGames", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.ChatsInAccounts", "AccountId", "dbo.Chats");
            DropForeignKey("dbo.ChatsInAccounts", "ChatId", "dbo.Accounts");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chats");
            DropIndex("dbo.GamesInAccounts", new[] { "AccountId" });
            DropIndex("dbo.GamesInAccounts", new[] { "GameId" });
            DropIndex("dbo.ScreenshotsInGames", new[] { "GameId" });
            DropIndex("dbo.ScreenshotsInGames", new[] { "ScreenshotId" });
            DropIndex("dbo.GenresInGames", new[] { "GameId" });
            DropIndex("dbo.GenresInGames", new[] { "GenreId" });
            DropIndex("dbo.DevelopersInGames", new[] { "GameId" });
            DropIndex("dbo.DevelopersInGames", new[] { "DeveloperId" });
            DropIndex("dbo.ChatsInAccounts", new[] { "AccountId" });
            DropIndex("dbo.ChatsInAccounts", new[] { "ChatId" });
            DropIndex("dbo.ProfileComments", new[] { "AuthorId" });
            DropIndex("dbo.ProfileComments", new[] { "ProfileId" });
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropTable("dbo.GamesInAccounts");
            DropTable("dbo.ScreenshotsInGames");
            DropTable("dbo.GenresInGames");
            DropTable("dbo.DevelopersInGames");
            DropTable("dbo.ChatsInAccounts");
            DropTable("dbo.ProfileComments");
            DropTable("dbo.Screenshots");
            DropTable("dbo.Genres");
            DropTable("dbo.Developers");
            DropTable("dbo.Games");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
            DropTable("dbo.Accounts");
        }
    }
}
