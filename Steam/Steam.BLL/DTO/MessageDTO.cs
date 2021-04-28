using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.DTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageTime { get; set; }

        public int SenderId { get; set; }

        public int ChatId { get; set; }
        public AccountDTO Sender { get; set; }
    }
}
