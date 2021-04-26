using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Steam.ViewModels
{
    class ChatViewModel : BaseNotifyPropertyChanged
    {
        public ICommand CloseCommand { get; private set; }
        public ICommand FSCommand { get; private set; }
        string baseDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        bool isFullScreen;
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

        public ChatViewModel()
        {
            SetStyles();
            InitCommands();
            WindowResizeImage = new BitmapImage(new Uri(baseDirectory + "\\WindowResize.png"));
        }
        public void InitCommands()
        {
            CloseCommand = new RelayCommand(x =>
            {
                Window window = x as Window;
                window.Close();
            });
            FSCommand = new RelayCommand(x =>
            {
                FullScreen(x as Window);
            });
        }

        private void SetStyles()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\Styles";
            if (Directory.Exists(path))
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(path + "\\MouseEnterStyle.xaml") });
            }
        }
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
