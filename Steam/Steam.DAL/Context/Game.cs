using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Game
    {
        public Game()
        {
            GamesInAccounts = new HashSet<Account>();
        }

        [Key]
        public int GameId { get; set; }
        [Required]
        [StringLength(128)]
        public string GameName { get; set; }

        [StringLength(2048)]
        public string GameInfo { get; set; }

        public virtual ICollection<Account> GamesInAccounts { get; set; } // 8

        public int GenreId { get; set; }

        public virtual Genre Genre {get; set;}
    }

}
