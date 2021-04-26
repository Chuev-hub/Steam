namespace Steam.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ChatsInAccounts", name: "ChatId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ChatsInAccounts", name: "AccountId", newName: "ChatId");
            RenameColumn(table: "dbo.GamesInAccounts", name: "GameId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.GamesInAccounts", name: "AccountId", newName: "GameId");
            RenameColumn(table: "dbo.ChatsInAccounts", name: "__mig_tmp__0", newName: "AccountId");
            RenameColumn(table: "dbo.GamesInAccounts", name: "__mig_tmp__1", newName: "AccountId");
            RenameIndex(table: "dbo.ChatsInAccounts", name: "IX_ChatId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.ChatsInAccounts", name: "IX_AccountId", newName: "IX_ChatId");
            RenameIndex(table: "dbo.GamesInAccounts", name: "IX_GameId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.GamesInAccounts", name: "IX_AccountId", newName: "IX_GameId");
            RenameIndex(table: "dbo.ChatsInAccounts", name: "__mig_tmp__0", newName: "IX_AccountId");
            RenameIndex(table: "dbo.GamesInAccounts", name: "__mig_tmp__1", newName: "IX_AccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GamesInAccounts", name: "IX_AccountId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.ChatsInAccounts", name: "IX_AccountId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GamesInAccounts", name: "IX_GameId", newName: "IX_AccountId");
            RenameIndex(table: "dbo.GamesInAccounts", name: "__mig_tmp__1", newName: "IX_GameId");
            RenameIndex(table: "dbo.ChatsInAccounts", name: "IX_ChatId", newName: "IX_AccountId");
            RenameIndex(table: "dbo.ChatsInAccounts", name: "__mig_tmp__0", newName: "IX_ChatId");
            RenameColumn(table: "dbo.GamesInAccounts", name: "AccountId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.ChatsInAccounts", name: "AccountId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GamesInAccounts", name: "GameId", newName: "AccountId");
            RenameColumn(table: "dbo.GamesInAccounts", name: "__mig_tmp__1", newName: "GameId");
            RenameColumn(table: "dbo.ChatsInAccounts", name: "ChatId", newName: "AccountId");
            RenameColumn(table: "dbo.ChatsInAccounts", name: "__mig_tmp__0", newName: "ChatId");
        }
    }
}
