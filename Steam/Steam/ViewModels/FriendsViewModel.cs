using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.Views;

namespace Steam.ViewModels
{
    class FriendsViewModel : BaseNotifyPropertyChanged
    {
        public static bool IsOpen = false;
        string baseDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        Visibility searchVisibility;
        public Visibility SearchVisibility
        {
            get => searchVisibility;
            set
            {
                searchVisibility = value;
                Notify();
            }
        }
        BitmapImage accountAvatar;
        public BitmapImage AccountAvatar
        {
            get => accountAvatar;
            set
            {
                accountAvatar = value;
                Notify();
            }
        }
        BitmapImage searchImage;
        public BitmapImage SearchImage
        {
            get => searchImage;
            set
            {
                searchImage = value;
                Notify();
            }
        }
        BitmapImage removeFriendsImage;
        public BitmapImage RemoveFriendsImage
        {
            get => removeFriendsImage;
            set
            {
                removeFriendsImage = value;
                Notify();
            }
        }
        BitmapImage addFriendsImage;
        public BitmapImage AddFriendsImage
        {
            get => addFriendsImage;
            set
            {
                addFriendsImage = value;
                Notify();
            }
        }
        string accountName;
        public string AccountName
        {
            get => accountName;
            set
            {
                accountName = value;
                Notify();
            }
        }
        public ICommand AddFriendCommand { get; set; }
        public ICommand RemoveFriendCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand OpenSearchCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand OpenChatCommand { get; set; }
        ObservableCollection<AccountDTO> friends;
        public ObservableCollection<AccountDTO> Friends
        {
            get => friends;
            set
            {
                friends = value;
                Notify();
            }
        }
        AccountDTO selectedFriend;
        public AccountDTO SelectedFriend 
        {
            get => selectedFriend;
            set
            {
                selectedFriend = value;
                Notify();
                //if(SearchVisibility == Visibility.Collapsed)
                //    OpenChat();
            }
        }

        AccountService AccountService;
        public FriendsViewModel(AccountService acs)
        {
            InitCommand();
            SetStyles();
            IsOpen = true;
            Friends = new ObservableCollection<AccountDTO>();
            AccountService = acs;
            SearchVisibility = Visibility.Collapsed;
            if(File.Exists(baseDirectory + "\\AddFriends.png"))
                AddFriendsImage = new BitmapImage(new Uri(baseDirectory + "\\AddFriends.png"));
            if (File.Exists(baseDirectory + "\\RemoveFriends.png"))
                RemoveFriendsImage = new BitmapImage(new Uri(baseDirectory + "\\RemoveFriends.png"));
            if (File.Exists(baseDirectory + "\\Search.png"))
                searchImage = new BitmapImage(new Uri(baseDirectory + "\\Search.png"));
            AccountAvatar = ToImage(Account.CurrentAccount.Avatar);
            AccountName = Account.CurrentAccount.Login;
            if (Account.CurrentAccount.AccountFriends != null)
                Friends.AddRange(Account.CurrentAccount.AccountFriends);
        }
        private void InitCommand()
        {
            AddFriendCommand = new RelayCommand(x =>
            {
                if (SelectedFriend != null)
                    AddFriend(SelectedFriend);
            });
            OpenSearchCommand = new RelayCommand(x =>
            {
                if (Account.CurrentAccount != null)
                    SearchVisibility = Visibility.Visible;
            });
            RemoveFriendCommand = new RelayCommand(x =>
            {
                if (SelectedFriend != null)
                {
                    Account.CurrentAccount.AccountFriends.Remove(SelectedFriend);
                    AccountService.CreateOrUpdate(Account.CurrentAccount);
                    Friends.Clear();
                    Friends.AddRange(Account.CurrentAccount.AccountFriends);
                }
            });
            CloseCommand = new RelayCommand(x =>
            {
                IsOpen = false;
                (x as Window).Close();
            });
            SearchCommand = new RelayCommand(x =>
            {
                if (Account.CurrentAccount != null)
                {
                    string str = x.ToString();
                    Friends.Clear();
                    Friends.AddRange(AccountService.GetAll().Where(y => y.Login.Contains(str) 
                                                && y.AccountId != Account.CurrentAccount.AccountId).ToList());
                }
            });
            RestoreCommand = new RelayCommand(x =>
            {
                if (Account.CurrentAccount != null)
                {
                    Friends.Clear();
                    Friends.AddRange(Account.CurrentAccount.AccountFriends);
                }
                SearchVisibility = Visibility.Collapsed;
            });
            OpenChatCommand = new RelayCommand(x =>
            {
                if (SearchVisibility == Visibility.Collapsed)
                {
                    ChatView view = new ChatView();
                    view.Show();
                }
            });
        }
        public BitmapImage ToImage(byte[] array)
        {
            if (array.Length > 0)
            {
                MemoryStream strmImg = new MemoryStream(array);
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.StreamSource = strmImg;
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();
                return myBitmapImage;
            }
            return new BitmapImage(new Uri(baseDirectory + "\\man.png"));
        }
        private void AddFriend(AccountDTO value)
        {
            if (value.Login.Length > 0)
            {
                Account.CurrentAccount.AccountFriends.Add(value);
                AccountService.CreateOrUpdate(Account.CurrentAccount);
            }
        }
        private void OpenChat()
        {
            ChatView view = new ChatView();
            view.Show();
        }
        private void SetStyles()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\Styles";
            if (Directory.Exists(path))
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(path + "\\MouseEnterStyle.xaml") });
            }
        }
    }
}
