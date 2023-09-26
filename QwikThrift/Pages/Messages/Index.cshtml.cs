#nullable disable
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Messages
{
    public class IndexModel : PageModel
    {
        private QwikThriftDbContext _dbContext;
        public List<Message> Messages { get; set; }
        public int NewMessages { get; set; }
        public string SearchKey { get; set; }

        public IndexModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult OnGet(string mode = "inbox")
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            ViewData["Mode"] = mode;

            //redirect user to login page if user is not logged in.
            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }
            
            var user = userMan.User;

            switch (mode)
            {
                case "inbox":
                    Messages = _dbContext.Messages.Where(m => m.RecipientId == user.UserId).OrderByDescending(m => m.Timestamp).ToList();
                    break;

                case "outbox":
                    Messages = _dbContext.Messages.Where(m => m.SenderId == user.UserId).OrderByDescending(m => m.Timestamp).ToList();
                    break;

                default:
                    Messages = new List<Message>();
                    break;
            }

            return Page();
        }
    }
}
