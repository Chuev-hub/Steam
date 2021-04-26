using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views.MainViewClilds.ShopViewChilds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class CatalogViewModel : BaseNotifyPropertyChanged
    {
        GameService gs;
        GameDTO curGame;
        int gamePos = 0;
        public GameDTO CurGame { get { return curGame; } set { curGame = value; Notify(); } }
        public CatalogViewModel(GameService gameService)
        {
            InitCommands();
            gs = gameService;
            foreach (var item in gs.GetAll())
            {
                Games.Add(item);
            }

            if (Games.Count > 0)
                CurGame = Games[gamePos];
        }

        private void InitCommands()
        {
            
            Prev = new RelayCommand(x => {

                if (Games.Count > 0 && gamePos == 0)
                {
                    gamePos = Games.Count;
                    CurGame = Games[--gamePos];
                }
            });
            Next = new RelayCommand(x => {

                if (Games.Count > 0 && gamePos == Games.Count - 1)
                {
                    gamePos = -1;
                    CurGame = Games[++gamePos];
                }

            });
            Game = new RelayCommand(x => {

                var GV = new GameView();
                (GV.DataContext as GameViewModel).Game = CurGame;
                Switcher.SwitchShop(GV);

            });
        }

        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
        public ICommand Prev { get; set; }
        public ICommand Next { get; set; }
        public ICommand Game { get; set; }
        
    }

}
