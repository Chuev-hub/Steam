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
        public virtual DbSet<GamesInAccounts> GamesInAccounts { get; set; }
        public virtual DbSet<AccountsInChats> AccountsInChats { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<ProfileComment> ProfileComment { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<DevelopersInGames> DevelopersInGames { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenresInGames> GenresInGames { get; set; }
        public virtual DbSet<Screenshot> Screenshots { get; set; }
        public virtual DbSet<ScreenshotsInGames> ScreenshotsInGames { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsInChats>().HasKey(u => new { u.AccountId, u.ChatId });
            modelBuilder.Entity<GamesInAccounts>().HasKey(u => new { u.AccountId, u.GameId });
            modelBuilder.Entity<DevelopersInGames>().HasKey(u => new { u.DeveloperId, u.GameId });
            modelBuilder.Entity<GenresInGames>().HasKey(u => new { u.GameId, u.GenreId });
            modelBuilder.Entity<ScreenshotsInGames>().HasKey(u => new { u.GameId, u.ScreenshotId });

            //modelBuilder.Entity<Account>()
            //    .HasMany(e => e.Games)
            //    .WithOptional(e => e.Account)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Account>()
            //    .HasMany(e => e.Chats)
            //    .WithOptional(e => e.Account)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Account>()
            //    .HasMany(e => e.Messages)
            //    .WithOptional(e => e.Sender)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Account>()
            //    .HasMany(e => e.AccountComments)
            //    .WithOptional(e => e.Profile)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Account>()
            //    .HasMany(e => e.LeftComments)
            //    .WithOptional(e => e.Author)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Chat>()
            //    .HasMany(e => e.AccountsInChats)
            //    .WithOptional(e => e.Chat)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Chat>()
            //    .HasMany(e => e.Messages)
            //    .WithOptional(e => e.Chat)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Game>()
            //    .HasMany(e => e.GamesInAccounts)
            //    .WithOptional(e => e.Game)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Genre>()
            //    .HasMany(e => e.Games)
            //    .WithOptional(e => e.Genre)
            //    .WillCascadeOnDelete(false);
        }
    }
}