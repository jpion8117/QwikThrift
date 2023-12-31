﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly QwikThriftDbContext _context;

        public DeleteModel(QwikThriftDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.DAL.Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userMan = new UserManager(HttpContext.Session, _context);

            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }

            var user = userMan.User ?? throw new ArgumentNullException();

            if (!user.CheckRole(UserRoles.Administrator))
            {
                NotificationBanner.SetBanner(HttpContext.Session,
                    "Only administrators may delete categories. If you believe this category violates our " +
                    "site's rules, please contact the administrator through the message center.",
                    "bg-danger text-center text-light",
                    10000);
                return RedirectToPage("/AccessDenied");
            }

            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                if (category.Listings.Count > 0)
                {
                    NotificationBanner.SetBanner(HttpContext.Session,
                        "Cannot delete non-empty category! Please use Force Delete to delete the category and all " +
                        "associated listings.",
                        "bg-danger text-center text-light",
                        10000);
                    return RedirectToPage("./ForceDelete", new { id = category.CategoryId });
                }

                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
