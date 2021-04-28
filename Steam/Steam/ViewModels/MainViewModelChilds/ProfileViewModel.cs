using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds;
using Steam.Views;
using Steam.Views.MainViewClilds;
using Steam.Views.MainViewClilds.ShopViewChilds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Steam.ViewModels.MainViewModelChilds
{
    class ProfileViewModel: BaseNotifyPropertyChanged
    {
        public string logo;
        public string Logo
        {
            get => logo;
            set
            {
                logo = value;
                Notify();
            }
        }
        public string Name
        {
            get => Account.CurrentAccount.ProfileName;
        }
        public string RealName
        {
            get => Account.CurrentAccount.RealName + ", " + Account.CurrentAccount.Country;
        }
          public ObservableCollection<GameDTO> Games
        {
            get;set;
        } = new ObservableCollection<GameDTO>();
        public BitmapImage Avatar
        {
            get {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new System.IO.MemoryStream(Account.CurrentAccount.Avatar);
                image.EndInit();
                return image;
            } 
        }
        public GameDTO selectedS;
        public GameDTO SelectedS { get => selectedS; set { selectedS = value; Notify(); } }
        GameService gameService;
        public void DoubleClickMethod()
        {
            var GV = new GameView();
            (GV.DataContext as GameViewModel).Game = gameService.Get( SelectedS.GameId);
            ShopView shopView = new ShopView();
            (shopView.DataContext as ShopViewModel).CurrentView = GV;
            Switcher.Switch(shopView);
        }
        public string More
        {
            get => Account.CurrentAccount.More;
        }
        public ProfileViewModel(GameService gameService)
        {
            this.gameService = gameService;
            Logo = Environment.CurrentDirectory + "\\Images\\back.png";
            Edit = new RelayCommand(x => {
                Switcher.Switch(new EditUserView());
            });

                Logout = new RelayCommand(x => {
                Account.CurrentAccount = null;
                if (File.Exists("Remember.txt"))
                    File.Delete("Remember.txt");
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    IdetifyView mainWindow = new IdetifyView();
                    mainWindow.Show();
                    Window ainWindow = Application.Current.Windows[0];
                    ainWindow.Close();
                });
            });
            Games.AddRange(Account.CurrentAccount.Games);

        }
        public ICommand Logout { get; set; }
        public ICommand Edit { get; set; }
        public Visibility Visible
        {
            get
            {
                if (Account.CurrentAccount.IsAdmin)
                    return Visibility.Visible;
                else
                    return Visibility.Hidden;

            }
        }

    }
}
