using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string PassHash { get; set; }
        public string Email { get; set; }
        public string ProfileName { get; set; }
        public string RealName { get; set; }
        public string Country { get; set; }
        public string More { get; set; }
        public bool IsAdmin { get; set; }


    }
}
