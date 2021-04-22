using GalaSoft.MvvmLight.Command;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views;
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
    class LoginViewModel : BaseNotifyPropertyChanged
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
        public bool isRemember;
        public bool IsRemember
        {
            get => isRemember;
            set
            {
                isRemember = value;
                Notify();
            }
        }
        public string logins;
        public string Logins
        {
            get => logins;
            set
            {
                logins = value;
                Notify();
            }
        }
        public LoginViewModel(AccountService s)
        {
            accountService = s;
            Logo = Environment.CurrentDirectory + "\\Images\\Ico.png";
            Init();
        }
        public ICommand Cancel { get; set; }
        public ICommand LoginCmd { get => new RelayCommand<object>(Login); }
        AccountService accountService;
        void Login(object obj)
        {
            if((obj as PasswordBox).Password == ""||Logins =="")
            {
                Error = "Fill all";
            }
            else
            {
                AccountDTO a = accountService.GetAll().ToList().Where(x => x.Login == Logins).FirstOrDefault();
                if (a != null && BCrypt.Net.BCrypt.Verify((obj as PasswordBox).Password, a.PassHash))
                {
                    Account.CurrentAccount = a;
                    if (IsRemember)
                        File.WriteAllText("Remember.txt", a.Login);
                    else
                        File.Delete("Remember.txt");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window ainWindow = Application.Current.MainWindow;
                    ainWindow.Close();

                }
                else
                    Error = "Not found";
            }
           

        }
        public string error;
        public string Error
        {
            get => error;
            set
            {
                error = value;
                Notify();
            }
        }
        public ICommand GoRegister { get; set; }
        void Init()
        {
            GoRegister = new Infrastructure.RelayCommand((x) =>
            {
                Switcher.Switch(new RegisterView());
            });
            Cancel = new Infrastructure.RelayCommand((x) =>
            {
                Environment.Exit(0);
            });
        }
    }
}
