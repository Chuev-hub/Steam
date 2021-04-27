using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Account
    {
        public Account()
        {
            Games = new HashSet<Game>();
            Chats = new HashSet<Chat>();
            Messages = new HashSet<Message>();
            ProfileComments = new HashSet<ProfileComment>();
            LeftComments = new HashSet<ProfileComment>();
            Wishlist = new HashSet<Game>();
            Basket = new HashSet<Game>();
        }
        [Key]
        public int AccountId { get; set; }
        [Required]
        [StringLength(64)]
        public string Login { get; set; }
        [Required]
        public string PassHash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(64)]
        public string ProfileName { get; set; }

        [StringLength(64)]
        public string RealName { get; set; }

        [StringLength(128)]
        public string Country { get; set; }

        [StringLength(1024)]
        public string More { get; set; }

        public byte[] Avatar { get; set; }

        public bool IsAdmin { get; set; }
        //public int FriendsLitsId { get; set; }
        //public virtual FriendsList FriendsList { get; set; } 
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Game> Wishlist { get; set; }
        public virtual ICollection<Game> Basket { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ProfileComment> ProfileComments { get; set; }
        public virtual ICollection<ProfileComment> LeftComments { get; set; }
    }
}
