using Castle.Core.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;
using QwikThrift.Models;

namespace QwikThrift.Pages.Messages
{
    public class EditModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;

        [BindProperty]
        public Message Message { get; set; } = new Message();

        [BindProperty]
        public string ReturnUrl { get; set; } = "/Messages/Index?mode=outbox";

        [BindProperty]
        public string Recipient { get; set; } = "";

        [BindProperty]
        public int SenderId { get; set; } = -1;

        public EditModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(int messageId = 0)
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);

            if (!userMan.UserLoggedIn)
            {
                return RedirectToPage("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }

            if (userMan.User != null)
            {
                SenderId = userMan.User.UserId;
            }
            else
                throw new ArgumentNullException("User not logged in"); //should never be thrown in theory...

            Message = _dbContext.Messages.FirstOrDefault(m => m.MessageId == messageId) ?? new Message();

            //verify the message was found and the editor is the original sender
            if (Message.MessageId != messageId) return NotFound();
            if (Message.SenderId != userMan.User.UserId) return RedirectToPagePermanent("/AccessDenied");

            return Page();
        }

        public IActionResult OnPost()
        {
            //check if recipient is a valid username
            Message.Recipient = _dbContext.Users.FirstOrDefault(u => u.Username == Recipient);

            Message.MessageEdited = true;
            Message.Body += $" - EDITED {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}";

            _dbContext.Messages.Update(Message);
            _dbContext.SaveChanges();

            NotificationBanner.SetBanner(HttpContext.Session,"Message edited successfully!", "bg-success text-white text-center");

            if (ReturnUrl.IsNullOrEmpty())
                return RedirectToPagePermanent("/Index");

            return RedirectPermanent(ReturnUrl);
        }
    }
}
