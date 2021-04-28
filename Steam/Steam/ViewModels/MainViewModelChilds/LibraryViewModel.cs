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
    class LibraryViewModel : BaseNotifyPropertyChanged
    {
        public GameDTO selected;
        public GameDTO Selected
        {
            get => selected; set
            {
                selected = value;
                urls = new List<string>(screenService.GetAll().Where(x => x.GameId == Selected.GameId).Select(x => x.ScreenshotURL));
                CountScreens = urls.Count;
                Screen = urls[0];
                if (urls == null || urls.Count == 0)
                    Visibility = System.Windows.Visibility.Hidden;
                else
                    Visibility = System.Windows.Visibility.Visible;
                Notify();
            }
        }

        public string screen;
        public string Screen
        {
            get => screen;
            set { screen = value; Notify(); }
        }

        int CountScreens;
        int CurrentScreen;
        GameService gameService;
        ScreenshotService screenService;
        List<string> urls;
        public LibraryViewModel(GameService gameService, ScreenshotService screenService)
        {

            this.gameService = gameService;
            this.screenService = screenService;
            Games.AddRange(Account.CurrentAccount.Games);

            ChangeLeft = new RelayCommand(x =>
            {
                if (CurrentScreen == CountScreens - 1)
                    CurrentScreen = 0;
                else
                    CurrentScreen++;
                Screen = urls[CurrentScreen];
            });
            ChangeRight = new RelayCommand(x =>
            {
                if (CurrentScreen == 0)
                    CurrentScreen = CountScreens - 1;
                else
                    CurrentScreen--;
                Screen = urls[CurrentScreen];

            });
            if (Account.CurrentAccount.Games.Count > 0)
                Selected = Account.CurrentAccount.Games[0]
            if (Selected != null && Selected.Screenshots.Count > 0)
            {
                Screen = urls[0];

            }
            if (urls == null || urls.Count == 0)
                Visibility = System.Windows.Visibility.Hidden;
            else
                Visibility = System.Windows.Visibility.Visible;

        }
        public void Reload()
        {
            Games.Clear();
            Games.AddRange(Account.CurrentAccount.Games);

            if (urls == null || urls.Count == 0)
                Visibility = System.Windows.Visibility.Hidden;
            else
                Visibility = System.Windows.Visibility.Visible;

        }

        public ICommand ChangeLeft { get; set; }
        public ICommand ChangeRight { get; set; }
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
        public System.Windows.Visibility visibility;
        public System.Windows.Visibility Visibility
        {
            get => visibility;
            set { visibility = value; Notify(); }

        }
    }
}