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
        public AccountDTO Account { get; set; }
        public UserControl CurrentView { get; set; }
        AccountService accountService;
        public MainViewModel(AccountService accountService)
        {
            InitCommands(); 
            this.accountService = accountService;
            accountService.CreateOrUpdate(new AccountDTO() {  Login = "123",PassHash="shashasha", Email ="milo", ProfileName ="Chel"});
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
