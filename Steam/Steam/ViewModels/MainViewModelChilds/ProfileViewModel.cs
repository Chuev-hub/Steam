﻿using Steam.BLL.DTO;
using Steam.Infrastructure;
using Steam.Views;
using Steam.Views.MainViewClilds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Steam.ViewModels.MainViewModelChilds
{
    class ProfileViewModel: BaseNotifyPropertyChanged
    {
        public string logo;
        public string Logo
        {
            get => logo;
            set
            {
                logo = value;
                Notify();
            }
        }
        public string Name
        {
            get => Account.CurrentAccount.ProfileName;
        }
        public string RealName
        {
            get => Account.CurrentAccount.RealName + ", " + Account.CurrentAccount.Country;
        }
        public List<GameDTO> Games
        {
            get => Account.CurrentAccount.Games;
        }
        public BitmapImage Avatar
        {
            get {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new System.IO.MemoryStream(Account.CurrentAccount.Avatar);
                image.EndInit();
                return image;
            } 
        }
        public string More
        {
            get => Account.CurrentAccount.More;
        }
        public ProfileViewModel()
        {
            Logo = Environment.CurrentDirectory + "\\Images\\back.png";
            Edit = new RelayCommand(x => {
                Switcher.Switch(new EditUserView());
            });

                Logout = new RelayCommand(x => {
                Account.CurrentAccount = null;
                if (File.Exists("Remember.txt"))
                    File.Delete("Remember.txt");
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    IdetifyView mainWindow = new IdetifyView();
                    mainWindow.Show();
                    Window ainWindow = Application.Current.Windows[0];
                    ainWindow.Close();
                });
            });
        }
        public ICommand Logout { get; set; }
        public ICommand Edit { get; set; }
        public Visibility Visible
        {
            get
            {
                if (Account.CurrentAccount.IsAdmin)
                    return Visibility.Visible;
                else
                    return Visibility.Hidden;

            }
        }

    }
}
