using CsQuery.ExtensionMethods.Internal;
using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.DAL.Context;
using Steam.DAL.Repositories;
using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Account = Steam.Infrastructure.Account;

namespace Steam.ViewModels
{
    class ChatViewModel : BaseNotifyPropertyChanged
    {
        public ICommand CloseCommand { get; private set; }
        public ICommand SendMessageCommand { get; private set; }
        BitmapImage friendImage;
        public BitmapImage FriendImage
        {
            get => friendImage;
            set
            {
                friendImage = value;
                Notify();
            }
        }
        string friendName;
        public string FriendName
        {
            get => friendName;
            set
            {
                friendName = value;
                Notify();
            }
        }
        ObservableCollection<MessageDTO> messages;
        public ObservableCollection<MessageDTO> Messages
        {
            get => messages;
            set
            {
                messages = value;
                Notify();
            }
        }
        string messageText;
        public string MessageText
        {
            get => messageText;
            set
            {
                messageText = value;
                Notify();
            }
        }
        ChatDTO chat;
        AccountDTO friend;
        AccountService AccountService;
        DispatcherTimer timer;
        int chatId;
        public ChatViewModel(AccountService acs)
        {
            SetTimer();
            SetStyles();
            InitCommands();
            AccountService = acs;
            Messages = new ObservableCollection<MessageDTO>();
        }
        private void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(ReloadMessage);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 700);
            
            timer.IsEnabled = true;
        }
        void SetChat()
        {
            ChatService cs = new ChatService(new ChatRepository(new SteamContext()));

            chat = cs.Get(chatId);
            Messages.Clear();
            Messages.AddRange(chat.Messages);
        }
        void InitCommands()
        {
            CloseCommand = new RelayCommand(x =>
            {
                timer.Stop();
                Window window = x as Window;
                window.Close();
            });
            SendMessageCommand = new RelayCommand(x =>
            {
                using (SteamContext context = new SteamContext())
                {
                    timer.Stop();
                    Message message = new Message();

                    message.MessageText = MessageText;
                    message.MessageTime = DateTime.Now;
                    message.Sender = context.Account.Where(y => y.AccountId == Account.CurrentAccount.AccountId).FirstOrDefault();
                    message.Chat = context.Chat.Where(y => y.ChatId == chatId).FirstOrDefault();

                    context.Message.Add(message);
                    context.SaveChanges();
                    MessageText = "";
                    timer.Start();
                }
            });
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
        public void SetFriend(AccountDTO fr)
        {
            using (SteamContext context = new SteamContext())
            {
                friend = AccountService.Get(fr.AccountId);
                FriendImage = FriendsViewModel.ToImage(friend.Avatar);
                FriendName = friend.Login;
                chatId = context.Chat.Where(x => x.Accounts
                            .Contains(context.Account.Where(y => y.AccountId == friend.AccountId).FirstOrDefault())
                            &&
                            x.Accounts
                            .Contains(context.Account.Where(y => y.AccountId == Account.CurrentAccount.AccountId).FirstOrDefault()))
                                .FirstOrDefault().ChatId;
                SetChat();
            }
        }
        void ReloadMessage(Object source, EventArgs e)
        {
            SetChat();
        }
    }
}
