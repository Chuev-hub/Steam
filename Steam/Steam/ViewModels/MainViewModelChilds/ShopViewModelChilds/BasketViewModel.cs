using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class BasketViewModel
    {
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
        public BasketViewModel()
        {
            Games.AddRange(Account.CurrentAccount.GamesInBasket);
        }
    }
}
