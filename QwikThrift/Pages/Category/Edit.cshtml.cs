using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly QwikThriftDbContext _context;

        public EditModel(QwikThriftDbContext context)
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

            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            //only allow original author or an administrator to edit
            if (!user.CheckRole(UserRoles.Administrator) && category.AuthorizedById != user.UserId)
            {
                NotificationBanner.SetBanner(HttpContext.Session,
                    "You do not have permission to edit this category. Please contact the original lister or an admin if you " +
                    "have any concerns.",
                    "bg-danger text-center text-light",
                    10000);
                return RedirectToPage("/AccessDenied");
            }

            Category = category;
            ViewData["AuthorizedById"] = category.AuthorizedById;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
