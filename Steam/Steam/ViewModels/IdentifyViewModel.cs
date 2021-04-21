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
        public IdetifyViewModel(AccountService d)
        {
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
            }
           
        }

        public void Navigate(UserControl page)
        {
            Current = page;
        }
    }
}
