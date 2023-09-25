#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Messages
{
    public class IndexModel : PageModel
    {
        public List<Message> Inbox { get; set; }
        public List<Message> Outbox { get; set; }
        public List<Message> Messages { get; set; }
        public int NewMessages { get; set; }
        public string SearchKey { get; set; }

        public IndexModel()
        {
            Inbox = new List<Message>();
            Outbox = new List<Message>();
            Messages = new List<Message>();
            Messages.Add(new Message());
            Messages.Add(new Message());
            Messages.Add(new Message());
            Messages[0].Subject = "Test Message";
            Messages[0].Sender = new Models.DAL.User();
            Messages[0].Sender.Username = "Test Subject A";
            Messages[0].Body = "This is the body of the first message ever to be displayed here. " +
                "which is pretty cool! Even if the message is actually fake and never went through" +
                "the system's database";
            Messages[1].Subject = "Test Message 2";
            Messages[1].Sender = new Models.DAL.User();
            Messages[1].Sender.Username = "Test Subject B";
            Messages[1].Body = "This is the body of the first message ever to be displayed here. " +
                "which is pretty cool! Even if the message is actually fake and never went through" +
                "the system's database";
            Messages[2].Subject = "RE: Test Message";
            Messages[2].Sender = new Models.DAL.User();
            Messages[2].Sender.Username = "Test Subject A";
            Messages[2].Body = "This is the body of the first message ever to be displayed here. " +
                "which is pretty cool! Even if the message is actually fake and never went through" +
                "the system's database";
            NewMessages = 0;
            SearchKey = string.Empty;
        }
        public void OnGet(string mode = "inbox")
        {
            ViewData["Mode"] = mode;
        }
    }
}
