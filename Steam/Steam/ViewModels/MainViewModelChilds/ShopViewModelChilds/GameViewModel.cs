using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class GameViewModel : BaseNotifyPropertyChanged
    {
        ScreenshotDTO selectedScreenshot;
        public ScreenshotDTO SelectedScreenshot { get { return selectedScreenshot; } set { selectedScreenshot = value; Notify(); } }
        GameDTO game;
        public GameDTO Game { get { return game; } set { game = value; Notify(); if (value.Screenshots.Count() > 0) SelectedScreenshot = value.Screenshots.FirstOrDefault(); } }

        AccountService accs;

        public GameViewModel(AccountService accs)
        {
            this.accs = accs;
            
            InitCommands();
        }

        private void InitCommands()
        {
            

            InBasket = new RelayCommand(x =>
            {
                using (var DB = new DAL.Context.SteamContext())
                {
                    var curAcc = DB.Account.Include("Basket").FirstOrDefault(y => y.AccountId == Infrastructure.Account.CurrentAccount.AccountId);

                    if (!curAcc.Basket.Any(y => y.GameId == Game.GameId))
                    {
                        curAcc.Basket.Add(DB.Game.FirstOrDefault(y => y.GameId == Game.GameId));
                    }
                    DB.SaveChanges();
                }
                //if (!Account.CurrentAccount.Basket.Any(y => y.GameId == Game.GameId))
                //{
                //    Account.CurrentAccount.Basket.Add(Game);
                //    accs.CreateOrUpdate(Account.CurrentAccount);
                //}
            });
            InWishlist = new RelayCommand(x =>
            {
                using (var DB = new DAL.Context.SteamContext())
                {
                    var curAcc = DB.Account.Include("Wishlist").FirstOrDefault(y => y.AccountId == Infrastructure.Account.CurrentAccount.AccountId);

                    if (!curAcc.Wishlist.Any(y => y.GameId == Game.GameId))
                    {
                        curAcc.Wishlist.Add(DB.Game.FirstOrDefault(y => y.GameId == Game.GameId));
                    }
                    DB.SaveChanges();
                }
                //if (!Account.CurrentAccount.Wishlist.Any(y => y.GameId == Game.GameId))
                //{
                //    Account.CurrentAccount.Wishlist.Add(Game);
                //    accs.CreateOrUpdate(Account.CurrentAccount);
                //}
            });
        }
        public ICommand InBasket { get; set; }
        public ICommand InWishlist { get; set; }
    }
}
