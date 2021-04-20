using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        [StringLength(2048)]
        public string MessageText { get; set; }

        [Required]
        public DateTime MessageTime { get; set; }

        [Required]
        public int SenderId { get; set; }

        public virtual Account Sender { get; set; } //3

        [Required]
        public int ChatId { get; set; }

        public virtual Chat Chat { get; set; } //7
    }
}
