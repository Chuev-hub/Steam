using Steam.BLL.DTO;
using Steam.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.ViewModels.MainViewModelChilds
{
    class ShopViewModel
    {
        GameService gs;
        public ShopViewModel(GameService gameService)
        {
            gs = gameService;
            foreach (var item in gs.GetAll())
            {
                Games.Add(item);
            }
            
        }
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
    }
}
