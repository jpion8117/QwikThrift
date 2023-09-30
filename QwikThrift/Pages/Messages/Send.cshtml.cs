using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Messages
{
    public class SendModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;
        public Message Message { get; set; } = new Message();

        public SendModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(string recipient = "", string subject = "", string body = "")
        {
            Message.Subject = subject;
            Message.Body = body;
        }
    }
}
