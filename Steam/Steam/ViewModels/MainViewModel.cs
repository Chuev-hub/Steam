using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Steam.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        public string Login
        {
            get => Account.CurrentAccount.ProfileName;
        }
        public UserControl CurrentView { get; set; }
        public MainViewModel(AccountService accountService)
        {
            InitCommands(); 
        }
        public void InitCommands()
        {
            ClickCommand = new RelayCommand(x =>
            {

            });

        }
        public ICommand ClickCommand { get; private set; }
    }
}
