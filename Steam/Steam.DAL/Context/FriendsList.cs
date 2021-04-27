using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class FriendsList
    {
        [Key]
        public int FriendsId { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
