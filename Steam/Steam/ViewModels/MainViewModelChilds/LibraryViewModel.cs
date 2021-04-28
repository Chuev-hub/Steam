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
using System.Windows.Media.Imaging;

namespace Steam.ViewModels.MainViewModelChilds
{
    class LibraryViewModel:BaseNotifyPropertyChanged
    {
        public GameDTO selected;
        public GameDTO Selected { get => selected; set { selected = value; Notify(); } }

        public string screen;
        public string Screen { get => screen; 
            set { screen = value; Notify(); } 
        }

        int CountScreens { get => Selected.Screenshots.Count; }
        int CurrentScreen;
        GameService gameService;
        public LibraryViewModel(GameService gameService)
        {
            this.gameService = gameService;
            Games.AddRange(Account.CurrentAccount.Games);
          
            ChangeLeft = new RelayCommand(x => {
                if (CurrentScreen == CountScreens - 1)
                    CurrentScreen = 0;
                else
                    CurrentScreen++;
                Screen = Selected.Screenshots.ToList()[CurrentScreen].ScreenshotURL ; 
            });
            ChangeRight = new RelayCommand(x => {
                if (CurrentScreen == 0)
                    CurrentScreen = CountScreens - 1;
                else
                    CurrentScreen--;
                Screen = Selected.Screenshots.ToList()[CurrentScreen].ScreenshotURL;

            });
            Screen = Selected.Screenshots.ToList()[0].ScreenshotURL;

        }
        public ICommand ChangeLeft { get; set; }
        public ICommand ChangeRight { get; set; }
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
    }
}
