using Steam.BLL.DTO;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class GameViewModel : BaseNotifyPropertyChanged
    {
        GameDTO game;
        public GameDTO Game { get { return game; } set { game = value; Notify(); } }
    }
}
