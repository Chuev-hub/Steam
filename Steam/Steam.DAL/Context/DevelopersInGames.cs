using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class DevelopersInGames
    {
        [Required]
        public int DeveloperId { get; set; }
        [Required]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
