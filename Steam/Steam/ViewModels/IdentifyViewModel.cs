using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views.IdentifyViewChilds;
using System;
using System.Collections.Generic;
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
    class IdetifyViewModel : BaseNotifyPropertyChanged, INavigate
    {
        public UserControl current;
        public UserControl Current
        {
            get=>current;
            set
            {
                current = value;
                Notify();
            }
        }
        AccountService accountService;
        public ICommand CloseCommand { get; private set; }
        public IdetifyViewModel(AccountService d)
        {
            SetStyles();
            InitCommand();
            if(!File.Exists("firstStart.txt"))
            {
                Task.Run(() => d.GetAll());
                File.Create("firstStart.txt");
            }
            accountService = d;
            Switcher.ContentArea = this;
            Switcher.Switch(new LoginView());
            if (File.Exists("Remember.txt"))
            {
                string s = File.ReadAllText("Remember.txt");
                Account.CurrentAccount = accountService.GetAll().Where(x => x.Login == s).FirstOrDefault();
                if(Account.CurrentAccount!=null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window ainWindow = Application.Current.MainWindow;
                    ainWindow.Close();
                }
                else
                    File.Delete("Remember.txt");
            }
        }

        private void InitCommand()
        {
            CloseCommand = new RelayCommand(x =>
            {
                Window window = x as Window;
                window.Close();
            });
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
        public void Navigate(UserControl page)
        {
            Current = page;
        }
    }
}
