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
        [Key]
        public int ScreenshotId { get; set; }
        public string ScreenshotURL { get; set; }
        public virtual ICollection<ScreenshotsInGames> Screenshots { get; set; }
    }
}
