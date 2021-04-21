using Ninject;
using Steam.BLL.Modules;
using Steam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Infrastructure
{
    class ViewModelsLocator
    {
        IKernel kernel;

        public ViewModelsLocator()
        {
            kernel = new StandardKernel(new SteamModule());
        }

        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();
        public IdentifyViewModel IdentifyViewModel => kernel.Get<IdentifyViewModel>();
        public LoginViewModel LoginViewModel => kernel.Get<LoginViewModel>();
    }
}
