﻿using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views;
using Steam.Views.MainViewClilds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Steam.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        public string Login
        {
            get => Account.CurrentAccount.ProfileName;
        }
        UserControl currentView;
        public UserControl CurrentView { 
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
        public UserControl LibraryView { get; set; }
        public MainViewModel(AccountService accountService)
        {
            InitCommands();
<<<<<<< HEAD
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            SteamClient.GetAndSaveGamesByList(File.ReadAllLines(path + "\\names.txt").ToList());

=======
            Switcher.ContentArea = this;
            Switcher.Switch(new ShopView());
           
            //SteamClient.GetAndSaveGamesByList(new List<string>()
            //{
            //    //"The Witcher 3: Wild Hunt",
            //    "Trove"
            //});
>>>>>>> b4fc2f812742ce4ef08a8d75df7a4a26067b8e91
        }
        public void InitCommands()
        {
            LibraryCommand = new RelayCommand(x =>
            {
                Switcher.Switch(LibraryView ?? (LibraryView = new LibraryView()));
            });
            ShopCommand = new RelayCommand(x =>
            {
                Switcher.Switch(new ShopView());
            });
            ProfileCommand = new RelayCommand(x =>
            {
                Switcher.Switch(new ProfileView());
            });
            ChatCommand = new RelayCommand(x =>
            {
                ChatView chatView = new ChatView();
                chatView.Show();
            });

        }

        public void Navigate(UserControl page)
        {
            CurrentView = page;
        }

        public ICommand LibraryCommand { get; private set; }
        public ICommand ShopCommand { get; private set; }
        public ICommand ProfileCommand { get; private set; }
        public ICommand ChatCommand { get; private set; }
    }
}
