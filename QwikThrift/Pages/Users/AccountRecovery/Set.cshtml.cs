using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Users.AccountRecovery
{
    public class SetModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;

        [BindProperty]
        public List<UserSecurityQuestion> UserSecurityQuestions { get; } = new List<UserSecurityQuestion> { 
            new UserSecurityQuestion(),
            new UserSecurityQuestion(),
            new UserSecurityQuestion()
        };

        public SetModel(QwikThrift.Models.DAL.QwikThriftDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var userMan = new UserManager(HttpContext.Session, _context);

            //redirect user to login page if user is not logged in.
            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }

            var user = userMan.User ?? throw new ArgumentNullException("User null when after login check.");

            foreach (var question in UserSecurityQuestions) 
            {
                question.User = user;
                question.UserId = user.UserId;
            }

            return Page();
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.SecurityQuestions == null)
            {
                return Page();
            }

            for (int index = 0; index < UserSecurityQuestions.Count; index++)
            {
                UserSecurityQuestion question = UserSecurityQuestions[index];
                bool error = false;

                if (question.Question.IsNullOrEmpty())
                {
                    ModelState.AddModelError($"SecurityQuestions[{index}].Question", "Please select a security question");
                    error = true;
                }
                if (question.Answer.IsNullOrEmpty())
                {
                    ModelState.AddModelError($"SecurityQuestions[{index}].Answer", "Please answer the security question.");
                    error = true;
                }
                if (error)
                    return Page();

                _context.SecurityQuestions.Add(question);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
