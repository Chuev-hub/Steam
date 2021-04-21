using Steam.Infrastructure;
using Steam.Views.IdentifyViewChilds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Steam.ViewModels
{
    class IdentifyViewModel : INavigate
    {
        public UserControl Current { get; set; }
        public IdentifyViewModel()
        {
            Switcher.ContentArea = this;
            Switcher.Switch(new LoginView());
        }

        public void Navigate(UserControl page)
        {
            Current = page;
        }
    }
}
