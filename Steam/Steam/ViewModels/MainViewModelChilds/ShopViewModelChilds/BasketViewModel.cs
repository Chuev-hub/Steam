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
                using (var DB = new DAL.Context.SteamContext())
                {
                    DB.Account.Include("Basket").FirstOrDefault(y => y.AccountId == Infrastructure.Account.CurrentAccount.AccountId).Basket.Remove(DB.Game.FirstOrDefault(y => y.GameId == g.GameId));
                }
            });
            Buy = new RelayCommand(x =>
            {
                using (var DB = new DAL.Context.SteamContext())
                {
                    var curAcc = DB.Account.Include("Basket").Include("Games").FirstOrDefault(y => y.AccountId == Infrastructure.Account.CurrentAccount.AccountId);

                    foreach (var item in curAcc.Basket)
                    {
                        curAcc.Games.Add(item);
                    }
                    curAcc.Basket.Clear();
                    Games.Clear();
                    FullPrice = 0;
                    DB.SaveChanges();
                }
            });
        }
        public ICommand RemoveGame { get; set; }
        public ICommand Buy { get; set; }
    }
}
