using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Users
{
    public class LogoutModel : PageModel
    {
        private QwikThriftDbContext _dbContext;

        public LogoutModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(string returnUrl = "")
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            userMan.DeleteUserSession();

            if (returnUrl.IsNullOrEmpty())
                return RedirectToPage("/Index");

            return Redirect(returnUrl);
        }
    }
}
