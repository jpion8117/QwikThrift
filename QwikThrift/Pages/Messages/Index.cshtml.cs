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

        [BindProperty]
        public string SortMode { get; set; }

        [BindProperty]
        public string Mode { get; set; }

        [BindProperty]
        public int MessageId { get; set; }

        public IndexModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult OnGet(string mode = "inbox", string sortMode = "", string searchString = "")
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            ViewData["Mode"] = mode;

            Mode = mode;
            SearchString = searchString;
            SortMode = sortMode;

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
                    messageQuery = _dbContext.Messages.Where(m => m.RecipientId == user.UserId && !m.RecipientDelete);
                    break;

                case "outbox":
                    messageQuery = _dbContext.Messages.Where(m => m.SenderId == user.UserId && !m.SenderDelete);
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
                if (!searchString.IsNullOrEmpty())
                {
                    //make search string lower-case
                    searchString = searchString.ToLower();

                    //extract subject string and filter
                    if (searchString.Contains("subject=\""))
                    {
                        string subjectStart = searchString.Substring(searchString.IndexOf("subject=\"") + 9);
                        string subject = subjectStart.Substring(0, subjectStart.IndexOf('\"'));
                        string subjectTagString = "subject=\"" + subject + "\"";

                        messageQuery = messageQuery.Where(m => m.Subject.Contains(subject));
                        searchString = searchString.Remove(searchString.IndexOf(subjectTagString), subjectTagString.Length);
                    }

                    //extract sender string and filter
                    if (searchString.Contains("sender=\""))
                    {
                        string senderStart = searchString.Substring(searchString.IndexOf("sender=\"") + 8);
                        string sender = senderStart.Substring(0, senderStart.IndexOf('\"'));
                        string senderTagString = "sender=\"" + sender + "\"";

                        messageQuery = messageQuery.Where(m => m.Sender.Username.Contains(sender));
                        searchString = searchString.Remove(searchString.IndexOf(senderTagString), senderTagString.Length);
                    }

                    //search remaining string on body
                    if (!searchString.IsNullOrEmpty())
                    {
                        var bodyWords = searchString.Split(' ');
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

        public IActionResult OnPostSendToTrash()
        {
            //find message
            var message = _dbContext.Messages.Find(MessageId);
            if (message == null) return NotFound();

            //determine if this is sender or recipient deleting the message
            if (Mode == "inbox")
                message.RecipientDelete = true;
            else 
                message.SenderDelete = true;

            //if both sender and recipient have deleted message, delete it from the database
            if (message.SenderDelete && message.RecipientDelete)
            {
                _dbContext.Remove(message);
                _dbContext.SaveChanges();
            }
            else
            {
                _dbContext.Update(message);
                _dbContext.SaveChanges();
            }

            return RedirectToPagePermanent("/Messages/Index", new { mode = Mode, sortMode = SortMode, searchString = SearchString });
        }
    }
}
