#nullable disable
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemCategory { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }
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

            var query = _dbContext.Listings
                .Where(listing => listing.OwnerId == userId);

            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(listing => listing.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ItemCategory))
            {
                query = query.Where(listing => listing.Category.CategoryName == ItemCategory);
            }


            switch (SortOrder)
            {
                case "ListingPriceAsc":
                    query = query.OrderBy(listing => listing.Price);
                    break;
                case "ListingPriceDesc":
                    query = query.OrderByDescending(listing => listing.Price);
                    break;

                default:
                    query = query.OrderByDescending(listing => listing.Price);
                    break;
            }

            Listings = query.ToList();
            Categories = new SelectList(_dbContext.Categories.Select(c => c.CategoryName).Distinct());

            return Page();
        }


    }
}
