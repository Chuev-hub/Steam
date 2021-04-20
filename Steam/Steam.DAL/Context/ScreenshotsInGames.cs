using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class ScreenshotsInGames
    {
        [Required]
        public int ScreenshotId { get; set; }
        [Required]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Screenshot Screenshot { get; set; }
    }
}
