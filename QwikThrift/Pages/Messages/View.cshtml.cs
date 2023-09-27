#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Messages
{
    public class ViewModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;
        public Message Message { get; private set; }
        public string ReturnMode { get; private set; }

        public ViewModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet() 
        {
            return RedirectToPagePermanent("/AccessDenied");
        }

        public void OnPost(int id, string mode)
        {
            //store mode
            ReturnMode = mode;

            //find and store message
            Message = _dbContext.Messages.FirstOrDefault(m => m.MessageId == id);

            //mark message as read if logged in user is message recipient
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            if (userMan.User != null && Message.RecipientId == userMan.User.UserId) { }
                Message.MessageRead = true;

            //save changes to the database
            _dbContext.Messages.Update(Message);
            _dbContext.SaveChanges();
        }
    }
}
