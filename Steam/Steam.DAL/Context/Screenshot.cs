using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Screenshot
    {
        public Screenshot()
        {
        }

        [Key]
        public int ScreenshotId { get; set; }
        public int GameId { get; set; }
        public string ScreenshotURL { get; set; }
        public virtual Game Game { get; set; }
    }
}
