using Ninject;
using Steam.BLL.Modules;
using Steam.ViewModels;
using Steam.ViewModels.MainViewModelChilds;
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
        public IdetifyViewModel IdentifyViewModel => kernel.Get<IdetifyViewModel>();
        public LoginViewModel LoginViewModel => kernel.Get<LoginViewModel>(); 
        public RegisterViewModel RegisterViewModel => kernel.Get<RegisterViewModel>(); 
        public ChatViewModel ChatViewModel => kernel.Get<ChatViewModel>(); 
        public ShopViewModel ShopViewModel => kernel.Get<ShopViewModel>(); 
        public ProfileViewModel ProfileViewModel => kernel.Get<ProfileViewModel>(); 
        public LibraryViewModel LibraryViewModel => kernel.Get<LibraryViewModel>(); 
    }
}
