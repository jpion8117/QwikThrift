using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QwikThrift.Models.DAL;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using QwikThrift.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace QwikThrift.Pages.Browse
{
    public class CreateModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;

        public CreateModel(QwikThrift.Models.DAL.QwikThriftDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var userMan = new UserManager(HttpContext.Session, _context);

            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }

            var userId = userMan.User.UserId;

            ViewData["AuthorizedById"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Categories == null || Category == null)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
