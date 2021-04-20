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
            GamesInAccounts = new HashSet<GamesInAccounts>();
        }

        [Key]
        public int GameId { get; set; }
        [Required]
        [StringLength(128)]
        public string GameName { get; set; }

        [StringLength(2048)]
        public string GameInfo { get; set; }
        public string Description { get; set; }
        public string HeaderImageURL { get; set; }
        public string Requirements { get; set; }
        public string RealeaseDate { get; set; }

        public virtual ICollection<ScreenshotsInGames> Screenshots { get; set; }
        public virtual ICollection<GamesInAccounts> GamesInAccounts { get; set; } // 8

        public virtual ICollection<GenresInGames> Genre { get; set; }
        public virtual ICollection<DevelopersInGames> Developers { get; set; }
    }

}
