#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace QwikThrift.Models.DAL
{
    public class Message
    {
        public int MessageId { get; set; }

        [ForeignKey("UserId")]
        public int SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("UserId")]
        public int RecipientId { get; set; }
        public User Recipient { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
