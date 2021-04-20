using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class GamesInAccounts
    {
        
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; } //8

        public virtual Account Account { get; set; } //1
    }
}
