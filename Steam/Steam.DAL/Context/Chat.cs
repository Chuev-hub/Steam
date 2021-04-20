using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Chat
    {
        public Chat()
        {
            AccountsInChats = new HashSet<AccountsInChats>();
            Messages = new HashSet<Message>();
        }

        public int ChatId { get; set; }

        public virtual ICollection<AccountsInChats> AccountsInChats { get; set; } //6

        public virtual ICollection<Message> Messages { get; set; } //7
    }
}
