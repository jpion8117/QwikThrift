﻿using System;
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
        public List<UserSecurityQuestion> UserSecurityQuestions { get; private set; } = new List<UserSecurityQuestion> { 
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
        public async Task<IActionResult> OnPostAsync(List<UserSecurityQuestion> userSecurityQuestions)
        {
            if (!ModelState.IsValid || _context.SecurityQuestions == null)
            {
                return Page();
            }

            var userMan = new UserManager(HttpContext.Session, _context);

            var user = userMan.User ?? throw new ArgumentNullException("User null when after login check.");

            var existingQuestions = _context.SecurityQuestions.Where(sq => sq.UserId == user.UserId).ToList();

            foreach (var question in existingQuestions)
            {
                _context.Remove(question);
            }

            await _context.SaveChangesAsync();
          
            for (int index = 0; index < userSecurityQuestions.Count; index++)
            {
                UserSecurityQuestion question = userSecurityQuestions[index];
                bool error = false;

                if (question.Question.IsNullOrEmpty())
                {
                    ModelState.AddModelError($"SecurityQuestions[{index}].Question", "Please select a security question");
                    error = true;
                }

                if (error)
                    return Page();

                _context.SecurityQuestions.Add(question);
            }

            await _context.SaveChangesAsync();

            return RedirectToPagePermanent("/Index");
        }
    }
}
