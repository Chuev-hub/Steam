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
            Games = new HashSet<Game>();
        }

        [Key]
        public int ScreenshotId { get; set; }
        public string ScreenshotURL { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
