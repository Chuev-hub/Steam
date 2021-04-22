using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Steam.ViewModels
{
    class ChatViewModel
    {
        public ChatViewModel()
        {
            InitCommands();
        }
        public void InitCommands()
        {
            CloseCommand = new RelayCommand(() =>
            {
                
            });
        }
        public ICommand CloseCommand { get; private set; }
    }
}
