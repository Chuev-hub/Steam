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
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class WishlistViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
        AccountService accs;
        public WishlistViewModel(AccountService accs)
        {
            this.accs = accs;
            Games.AddRange(Account.CurrentAccount.Wishlist);
            InitCommands();
        }


        private void InitCommands()
        {
            RemoveGame = new RelayCommand(x =>
            {
                var g = x as GameDTO;
                Games.Remove(g);
                Account.CurrentAccount.Wishlist.Remove(g);
            });
            InBasket = new RelayCommand(x =>
            {
                var Game = x as GameDTO;
                if (!Account.CurrentAccount.Basket.Any(y => y.GameId == Game.GameId))
                {
                    Account.CurrentAccount.Basket.Add(Game);
                    accs.CreateOrUpdate(Account.CurrentAccount);
                }
            });
        }
        public ICommand RemoveGame { get; set; }
        public ICommand InBasket { get; set; }
    }
}
