using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class GenresInGames
    {
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int GameId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Game Game { get; set; }
    }
}
