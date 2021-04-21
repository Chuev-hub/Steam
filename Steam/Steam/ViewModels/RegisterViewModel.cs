using Steam.Infrastructure;
using Steam.Views.IdentifyViewChilds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public RegisterViewModel()
        {
            Logo = Environment.CurrentDirectory + "\\Images\\Ico.png";
            Init();
        }
        public ICommand GoLogin { get; set; }
        void Init()
        {
            GoLogin = new RelayCommand((x) =>
            {
                Switcher.Switch(new LoginView());
            });
        }
    }
}
