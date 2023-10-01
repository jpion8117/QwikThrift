using Castle.Core.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Messages
{
    public class SendModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;

        [BindProperty]
        public Message Message { get; set; } = new Message();

        [BindProperty]
        public string ReturnUrl { get; set; } = "";

        [BindProperty]
        public string Recipient { get; set; } = " ";

        [BindProperty]
        public int SenderId { get; set; } = -1;

        public SendModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(string recipient = "", string subject = "", string body = "", string returnUrl = "")
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);

            if (!userMan.UserLoggedIn) 
            {
                return RedirectToPage("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }

            Message.Subject = subject;
            Message.Body = body;
            ReturnUrl = returnUrl;
            Recipient = recipient;

            if (userMan.User != null)
            {
                Message.Sender = userMan.User;
                SenderId = userMan.User.UserId;
            }
            else
                throw new ArgumentNullException("User not logged in"); //should never be thrown in theory...

            return Page();
        }

        public IActionResult OnPost()
        {
            //check if recipient is a valid username
            Message.Recipient = _dbContext.Users.FirstOrDefault(u => u.Username == Recipient);

            if (Message.Recipient == null)
            {
                ModelState.AddModelError("Recipient", "User not found, please try again.");
                return Page();
            }

            Message.SenderId = SenderId;
            Message.RecipientId = Message.Recipient.UserId;
            Message.Timestamp = DateTime.Now;

            _dbContext.Messages.Add(Message);
            _dbContext.SaveChanges();

            if (ReturnUrl.IsNullOrEmpty())
                return RedirectToPagePermanent("/Index");

            return RedirectPermanent(ReturnUrl);
        }
    }
}
