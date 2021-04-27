using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class GameViewModel : BaseNotifyPropertyChanged
    {
        ScreenshotDTO selectedScreenshot;
        public ScreenshotDTO SelectedScreenshot { get { return selectedScreenshot; } set { selectedScreenshot = value;Notify(); } }
        GameDTO game;
        public GameDTO Game { get { return game; } set { game = value; Notify(); if (value.Screenshots.Count>0)SelectedScreenshot = value.Screenshots[0]; } }

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
                if (!Account.CurrentAccount.GamesInBasket.Contains(Game))
                    Account.CurrentAccount.GamesInBasket.Add(Game);
                accs.CreateOrUpdate(Account.CurrentAccount);
            });
        }
        public ICommand InBasket { get; set; }
    }
}
