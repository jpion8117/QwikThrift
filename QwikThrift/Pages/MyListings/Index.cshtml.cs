#nullable disable
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using QwikThrift.Models;
using QwikThrift.Models.DAL;
using System.Collections.Generic;
using System.Linq;

namespace QwikThrift.Pages.MyListings
{
    public class IndexModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;
        public List<Listing> Listings { get; set; } 

        public string SearchString { get; set; }

        public IndexModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet()
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);

            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }

            var userId = userMan.User.UserId;

            Listings = _dbContext.Listings
                .Where(listing => listing.OwnerId == userId)
                .ToList();

            return Page();
        }
    }
}
