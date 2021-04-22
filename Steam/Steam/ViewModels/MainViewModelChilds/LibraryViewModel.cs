using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.ViewModels.MainViewModelChilds
{
    class LibraryViewModel
    {
        GameService gameService;
        public LibraryViewModel(GameService gameService)
        {
            //gameService.GetAll().Where(x => x.)
            //Account.CurrentAccount.AccountId;
            //this.gameService = gameService;
            //foreach (var item in gameService.GetAll())
            //{
            //    Games.Add(item);
            //}
            
        }
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
    }
}
