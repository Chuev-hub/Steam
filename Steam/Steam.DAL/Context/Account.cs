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
            Games = new HashSet<GamesInAccounts>();
            Chats = new HashSet<AccountsInChats>();
            Messages = new HashSet<Message>();
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

        public bool IsAdmin { get; set; }

        public virtual ICollection<GamesInAccounts> Games { get; set; } //1
        public virtual ICollection<AccountsInChats> Chats { get; set; } //2
        public virtual ICollection<Message> Messages { get; set; } //3
        public virtual ICollection<ProfileComment> AccountComments { get; set; } //4
        public virtual ICollection<ProfileComment> LeftComments { get; set; } //5
    }
}
