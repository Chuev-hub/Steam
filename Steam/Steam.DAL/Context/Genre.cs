using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Genre
    {
        public Genre()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Game> Games { get; set; } // 9
    }
}
