﻿#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace QwikThrift.Models.DAL
{
    public class Message
    {
        public int MessageId { get; set; }

        public int SenderId { get; set; }
        virtual public User Sender { get; set; }

        public int RecipientId { get; set; }
        virtual public User Recipient { get; set; }

        public bool MessageRead { get; set; }

        public bool MessageEdited { get; set; }

        public bool SenderDelete { get; set; }

        public bool RecipientDelete { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
