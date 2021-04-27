﻿using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Steam.ViewModels.MainViewModelChilds.ShopViewModelChilds
{
    class BasketViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
        public BasketViewModel()
        {
            Games.AddRange(Account.CurrentAccount.Basket);
            FullPrice = Games.Sum(x => x.Price);
            InitCommands();
        }

        decimal fullPrice;
        public decimal FullPrice { get { return fullPrice; } set { fullPrice = value; Notify(); } }

        private void InitCommands()
        {
            RemoveGame = new RelayCommand(x =>
            {
                var g = x as GameDTO;
                FullPrice -= g.Price;
                Games.Remove(g);
                Account.CurrentAccount.Basket.Remove(g);
            });
        }
        public ICommand RemoveGame { get; set; }
    }
}
