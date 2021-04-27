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
        public ScreenshotDTO SelectedScreenshot { get { return selectedScreenshot; } set { selectedScreenshot = value;Notify(); } }
        GameDTO game;
        public GameDTO Game { get { return game; } set { game = value; Notify(); if (value.Screenshots.Count>0)SelectedScreenshot = value.Screenshots.FirstOrDefault(); } }

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
                //MessageBox.Show(accs.GetAll().ToList()[0].Games.Count.ToString());
                if (!Account.CurrentAccount.Basket.Contains(Game))
                {
                    Account.CurrentAccount.Basket.Add(Game);
                    accs.CreateOrUpdate(Account.CurrentAccount);
                }
            });
        }
        public ICommand InBasket { get; set; }
    }
}
