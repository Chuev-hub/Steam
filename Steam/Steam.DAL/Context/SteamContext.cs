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
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<ProfileComment> ProfileComment { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Screenshot> Screenshots { get; set; }


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
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Chats_Accounts").MapLeftKey("AccountId").MapRightKey("ChatId"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Games)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Games_Accounts").MapLeftKey("AccountId").MapRightKey("GameId"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Basket)
                .WithMany(e => e.Baskets)
                .Map(m => m.ToTable("Games_Baskets").MapLeftKey("AccountId").MapRightKey("GameId"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Wishlist)
                .WithMany(e => e.Wishlists)
                .Map(m => m.ToTable("Games_Wishlists").MapLeftKey("AccountId").MapRightKey("GameId"));

            modelBuilder.Entity<Chat>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Developer>()
                .HasMany(e => e.Games)
                .WithMany(e => e.Developers)
                .Map(m => m.ToTable("Developers_Games").MapLeftKey("DeveloperId").MapRightKey("GameId"));

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Games)
                .WithMany(e => e.Genres)
                .Map(m => m.ToTable("Genres_Games").MapLeftKey("GenreId").MapRightKey("GameId"));

            modelBuilder.Entity<Screenshot>()
                .HasMany(e => e.Games)
                .WithMany(e => e.Screenshots)
                .Map(m => m.ToTable("Screenshots_Games").MapLeftKey("ScreenshotId").MapRightKey("GameId"));

            //modelBuilder.Entity<Account>()
            //    .HasMany(e => e.Friends)
            //    .WithMany(e => e.AccountFriends)
            //    .Map(m => m.ToTable("FriendList").MapLeftKey("AccountId").MapRightKey("AccountId"));

        }
    }
}