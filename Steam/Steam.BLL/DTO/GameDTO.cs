using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameInfo { get; set; }
        public string Description { get; set; }
        public string HeaderImageURL { get; set; }
        public string Requirements { get; set; }
        public string RealeaseDate { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public virtual List<ScreenshotDTO> Screenshots { get; set; }
        public virtual List<AccountDTO> Baskets { get; set; }
    }
}
