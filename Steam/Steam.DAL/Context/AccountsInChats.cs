using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class AccountsInChats
    {
        
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int ChatId { get; set; }

        public virtual Account Account { get; set; } //2

        public virtual Chat Chat { get; set; }  //6
    }
}
