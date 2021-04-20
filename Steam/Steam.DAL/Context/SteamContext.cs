using System;
using System.Data.Entity;
using System.Linq;

namespace Steam.DAL.Context
{
    public class SteamContext : DbContext
    {
        public SteamContext()
            : base("name=SteamContext")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<ProfileComment> ProfileComment { get; set; }
        public virtual DbSet<Message> Message { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Sender)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.ProfileComments)
                .WithRequired(e => e.Profile)
                .HasForeignKey(e => e.ProfileId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.LeftComments)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Chats)
                .WithMany(e => e.AccountsInChats)
                .Map(m => m.ToTable("AccountsInChats").MapLeftKey("AccountId").MapRightKey("ChatId"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Games)
                .WithMany(e => e.GamesInAccounts)
                .Map(m => m.ToTable("GamesInAccounts").MapLeftKey("AccountId").MapRightKey("GameId"));

            modelBuilder.Entity<Chat>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}