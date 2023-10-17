using System;
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
    public class ForceDeleteModel : PageModel
    {
        private readonly QwikThriftDbContext _context;

        public ForceDeleteModel(QwikThriftDbContext context)
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
                foreach (var listing in category.Listings)
                {
                    listing.DeleteAssociatedImages();
                    
                    foreach(var image in  listing.Images) 
                    {
                        _context.ImageReferences.Remove(image);
                    }

                    var message = new QwikThrift.Models.DAL.Message
                    {
                        SenderId = 1, //administrator
                        RecipientId = listing.OwnerId,
                        Timestamp = DateTime.Now,
                        Subject = $"The category containing your listing \"{listing.Title}\" has been deleted.",
                        Body = $"This is an automated message:\n\n" +
                        $"An administrator has deleted the category \"{category.CategoryName}.\" This " +
                        $"usually happens when a category voiolates our site's rules. Your listing, \"{listing.Title},\" " +
                        $"has been deleted as well. If you believe your listing did not violate any rules, you may repost " +
                        $"it under another related category.\n\nThank you for your cooperation,\n\nQwikThrift Admin Team"
                    };

                    _context.Messages.Add(message);

                    _context.Listings.Remove(listing);
                }

                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}