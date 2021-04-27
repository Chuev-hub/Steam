using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views;
using Steam.Views.MainViewClilds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Steam.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        string baseDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public string Login
        {
            get => Account.CurrentAccount.Login;
        }
        UserControl currentView;
        public UserControl CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                Notify();
            }
        }
        public UserControl LibraryView { get; set; }
        BitmapImage windowResizeImage;
        public BitmapImage WindowResizeImage
        {
            get => windowResizeImage;
            set
            {
                windowResizeImage = value;
                Notify();
            }
        }

        public MainViewModel(AccountService accountService, GenreService gs)
        {
            SetStyles();
            InitCommands();

            WindowResizeImage = new BitmapImage(new Uri(baseDirectory + "\\WindowResize.png"));

            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            int count = gs.GetAll().Count();
            if (count <= 0 || count < File.ReadAllLines(baseDirectory + "\\names.txt").Length)
                SteamClient.GetAndSaveGamesByList(File.ReadAllLines(path + "\\names.txt").ToList());
            Switcher.ContentArea = this;
            Switcher.Switch(new ShopView());
       
        }
        void SetStyles()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\Styles";
            if (Directory.Exists(path))
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(path + "\\MouseEnterStyle.xaml") });
            }
        }
        public void InitCommands()
        {
            LibraryCommand = new RelayCommand(x =>
            {
                Switcher.Switch(LibraryView ?? (LibraryView = new LibraryView()));
            });
            ShopCommand = new RelayCommand(x =>
            {
                Switcher.Switch(new ShopView());
            });
            ProfileCommand = new RelayCommand(x =>
            {
                Switcher.Switch(new ProfileView());
            });
            ChatCommand = new RelayCommand(x =>
            {
                ChatView chatView = new ChatView();
                chatView.Show();
            });
            FSCommand = new RelayCommand(x =>
            {
                FullScreen(x as Window);
            });
            CloseCommand = new RelayCommand(x =>
            {
                Window window = x as Window;
                window.Close();
            });
        }

        public void Navigate(UserControl page)
        {
            CurrentView = page;
        }

        public ICommand LibraryCommand { get; private set; }
        public ICommand ShopCommand { get; private set; }
        public ICommand ProfileCommand { get; private set; }
        public ICommand ChatCommand { get; private set; }
        public ICommand FSCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        bool isFullScreen;
        void FullScreen(Window mainView)
        {
            if (!isFullScreen)
                mainView.WindowState = WindowState.Maximized;
            else
                mainView.WindowState = WindowState.Normal;
            isFullScreen = !isFullScreen;
        }
    }
}
