#nullable disable
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;
using System.ComponentModel.DataAnnotations;

namespace QwikThrift.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;

        /// <summary>
        /// Store a JSON formatted string for arguments to be sent with the ReturnURL
        /// upon successful login
        /// </summary>
        [BindProperty]
        public string ReturnArgs { get; set; }
        
        /// <summary>
        /// Store a URL for the user to be returned to upon successful login
        /// </summary>
        [BindProperty]
        public string ReturnURL { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your username to continue...")]
        public string Username { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password to continue...")]
        public string Password { get; set; }

        public LoginModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(string returnUrl = "")
        {
            ReturnURL = returnUrl;
        }
   
        public IActionResult OnPost()
        { 
            if (ModelState.IsValid) 
            {
                //verify user credentials
                //locate user account
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == Username);

                if (user == null || !user.verifyLogin(Password))
                {
                    ModelState.AddModelError("Username", "Invalid username or password...");
                    return Page();
                }

                //username and password match. Great Success!!!
                //register user login
                var userMan = new UserManager(HttpContext.Session, _dbContext);
                userMan.SaveUserSession(user);

                //return user to redirected page
                if (ReturnURL.IsNullOrEmpty())
                    return Redirect("/");

                return RedirectPermanent(ReturnURL);
            }

            return Page();
        }
    }
}
