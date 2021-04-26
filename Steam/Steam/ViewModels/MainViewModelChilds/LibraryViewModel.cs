using CsQuery.ExtensionMethods.Internal;
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
            this.gameService = gameService;
            Games.AddRange(Account.CurrentAccount.Games);
        }
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
    }
}
