using Steam.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Infrastructure
{
    public static class Account
    {
        public static AccountDTO CurrentAccount { get; set; }// = new AccountDTO() { Login = "System", Email = "System", ProfileName = "System", PassHash = "System" };
    }
}