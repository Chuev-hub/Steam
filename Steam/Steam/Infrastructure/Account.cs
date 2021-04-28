using Steam.BLL.DTO;
using Steam.BLL.Services;
using Steam.DAL.Context;
using Steam.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Infrastructure
{
    public static class Account
    {
        public static AccountDTO CurrentAccount
        {
            get => Service.Get(acc.AccountId);
            set => acc = value;
        }
        static AccountDTO acc;
        static AccountService Service { get; set; } = new AccountService(new AccountRepository(new SteamContext()));
        static public void Method() { }
    }
}