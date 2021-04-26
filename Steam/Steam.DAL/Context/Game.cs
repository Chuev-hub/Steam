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
            Accounts = new HashSet<Account>();
            Genres = new HashSet<Genre>();
            Screenshots = new HashSet<Screenshot>();
            Developers = new HashSet<Developer>();
        }

        [Key]
        public int GameId { get; set; }
        [Required]
        [StringLength(128)]
        public string GameName { get; set; }
        public string GameInfo { get; set; }
        public string Description { get; set; }
        public string HeaderImageURL { get; set; }
        public string Requirements { get; set; }
        public string RealeaseDate { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } // 8
        public virtual ICollection<Screenshot> Screenshots { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Developer> Developers { get; set; }
    }

}
