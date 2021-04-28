using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.DTO
{
    public class ScreenshotDTO
    {
        public int ScreenshotId { get; set; }
        public int GameId { get; set; }
        public string ScreenshotURL { get; set; }
    }
}
