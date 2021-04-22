using GalaSoft.MvvmLight.Command;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.DAL.Repositories;
using Steam.Infrastructure;
using Steam.Views.IdentifyViewChilds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Steam.ViewModels
{
    class RegisterViewModel:BaseNotifyPropertyChanged
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
        public string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                Notify();
            }
        }
        public string mail;
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                Notify();
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
        public RegisterViewModel(AccountService s)
        {
            accountService = s;
            Logo = Environment.CurrentDirectory + "\\Images\\Ico.png";
            Init();
        }
        public ICommand GoLogin { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand RegisterCmd { get => new RelayCommand<object>(Register); }
        void Init()
        {
            GoLogin = new Infrastructure.RelayCommand((x) =>
            {
                Switcher.Switch(new LoginView());
            });
            Cancel = new Infrastructure.RelayCommand((x) =>
            {
                Environment.Exit(0);
            });
        }
        bool a = false;
        AccountService accountService;
        void Register(object obj)
        {
           
            Task.Run(() => {
                string password = BCrypt.Net.BCrypt.HashPassword((obj as PasswordBox).Password);
                try
                {
                    if (Name == "" || Mail == "" || (obj as PasswordBox).Password == "")
                    {
                        Error = "Fill all";
                    }
                    else
                    {
                        if (accountService.GetAll().ToList().Where(x => x.Login == Name).FirstOrDefault() == null)
                        {
                            accountService.CreateOrUpdate(new AccountDTO()
                            {
                                Email = Mail,
                                Login = Name,
                                ProfileName = Name,
                                PassHash = password
                            });
                            a = true;
                        }
                        else
                            Error = "Change Name";
                    }
                }
                catch { a = false; }
            }).ContinueWith((x)=> {
                if (Name != "" && Mail != "" && (obj as PasswordBox).Password != ""&&a==true)
                    Application.Current.Dispatcher.Invoke((Action)delegate {
                        Switcher.Switch(new LoginView());
                    });
               
            });
           

        }
    }
}
