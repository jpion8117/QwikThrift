#nullable disable
using Castle.Core.Internal;
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

        [BindProperty]
        public string SearchString { get; set; }

        public IndexModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult OnGet(string mode = "inbox", string sortMode = "", string SearchString = "")
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            ViewData["Mode"] = mode;

            //redirect user to login page if user is not logged in.
            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }
            
            var user = userMan.User;
            ViewData["UnreadMessages"] = _dbContext.Messages
                .Where(m => m.RecipientId == user.UserId && m.MessageRead == false)
                .ToList().Count;

            IQueryable<Message> messageQuery;

            switch (mode)
            {
                case "inbox":
                    messageQuery = _dbContext.Messages.Where(m => m.RecipientId == user.UserId);
                    break;

                case "outbox":
                    messageQuery = _dbContext.Messages.Where(m => m.SenderId == user.UserId);
                    break;

                default:
                    Messages = new List<Message>();
                    return Page();
            }

            if(messageQuery != null) 
            {
                //sort messages based on sort mode
                switch (sortMode)
                {
                    case "asc":
                        messageQuery = messageQuery.OrderBy(m => m.Timestamp);
                        break;
                    case "desc":
                    default:
                        messageQuery = messageQuery.OrderByDescending(m => m.Timestamp);
                        break;
                }

                //apply search rules
                if (!SearchString.IsNullOrEmpty())
                {
                    //make search string lower-case
                    SearchString = SearchString.ToLower();

                    //extract subject string and filter
                    if (SearchString.Contains("subject=\""))
                    {
                        string subjectStart = SearchString.Substring(SearchString.IndexOf("subject=\"") + 9);
                        string subject = subjectStart.Substring(0, subjectStart.IndexOf('\"'));
                        string subjectTagString = "subject=\"" + subject + "\"";

                        messageQuery = messageQuery.Where(m => m.Subject.Contains(subject));
                        SearchString = SearchString.Remove(SearchString.IndexOf(subjectTagString), subjectTagString.Length);
                    }

                    //extract sender string and filter
                    if (SearchString.Contains("sender=\""))
                    {
                        string senderStart = SearchString.Substring(SearchString.IndexOf("sender=\"") + 8);
                        string sender = senderStart.Substring(0, senderStart.IndexOf('\"'));
                        string senderTagString = "sender=\"" + sender + "\"";

                        messageQuery = messageQuery.Where(m => m.Sender.Username.Contains(sender));
                        SearchString = SearchString.Remove(SearchString.IndexOf(senderTagString), senderTagString.Length);
                    }

                    //search remaining string on body
                    if (!SearchString.IsNullOrEmpty())
                    {
                        var bodyWords = SearchString.Split(' ');
                        foreach (var word in bodyWords)
                        { 
                            messageQuery = messageQuery.Where(m => m.Body.Contains(word));
                        }
                    }
                }

                Messages = messageQuery.ToList();
            }
            else
                return NotFound();

            return Page();
        }
    }
}
