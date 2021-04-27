using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds;
using Steam.Views.MainViewClilds.ShopViewChilds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds
{
    class ShopViewModel : BaseNotifyPropertyChanged, INavigate
    {
        
        string searchText;
        public string SearchText { get { return searchText; } set { searchText = value; Notify(); } }
        GameService gs;
        public ShopViewModel(GameService gameService)
        {
            Switcher.ContentAreaShop = this;
            gs = gameService;
            InitCommands();
            Catalog.Execute(this);
        }

        private void InitCommands()
        {
            Search = new RelayCommand(x =>
            {
                var SV = new SearchView();
                (SV.DataContext as SearchViewModel).SearchText = SearchText;
                (SV.DataContext as SearchViewModel).Search.Execute(this);
                CurrentView = SV;

            });

            Catalog = new RelayCommand(x =>
            {
                CurrentView = new CatalogView();
            });
            Basket = new RelayCommand(x =>
            {
                CurrentView = new BasketView();
            });
        }

        public void Navigate(UserControl page)
        {
            CurrentView = page;
        }

        public ICommand Search { get; set; }
        public ICommand Catalog { get; set; }
        public ICommand Basket { get; set; }



        UserControl currentView;
        public UserControl CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                Notify();
            }
        }

        
    }
}
