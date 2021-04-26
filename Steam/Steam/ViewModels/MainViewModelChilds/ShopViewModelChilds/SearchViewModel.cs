using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views.MainViewClilds.ShopViewChilds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class SearchViewModel : BaseNotifyPropertyChanged
    {
        string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                Notify();
                
            }
        }
        string searchResult;
        public string SearchResult
        {
            get
            {
                return searchResult;
            }
            set
            {
                searchResult = value;
                Notify();
            }
        }
        GameService gs;
        public SearchViewModel(GameService gs)
        {
            this.gs = gs;
            InitCommands();
        }

        private void InitCommands()
        {
            Search = new RelayCommand(x =>
            {
                Games.Clear();
                Games.AddRange(gs.GetAll().Where(y => y.GameName.ToLower().Contains(SearchText.ToLower())));
                SearchResult = $"Результатов по вашему запросу {Games.Count}.";
            });
        }

        GameDTO curGame;
        public GameDTO CurGame 
        { 
            get 
            { 
                return curGame;
            } 
            set 
            { 
                curGame = value;
                Notify();

                var GV = new GameView();
                (GV.DataContext as GameViewModel).Game = value;
                Switcher.SwitchShop(GV);


            } 
        }
        public ICommand Search { get; set; }
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
    }
}
