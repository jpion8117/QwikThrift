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

namespace QwikThrift.Pages.Browse
{
    public class BrowseModel : PageModel
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
        public BrowseModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet()
        {
            var query = _dbContext.Listings
            .OrderByDescending(listing => listing.ListingTime)
            .Take(5);

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
                case "ListingTimeAsc":
                    query = query.OrderBy(listing => listing.ListingTime);
                    break;
                case "ListingTimeDesc":
                    query = query.OrderByDescending(listing => listing.ListingTime);
                    break;

                default:
                    query = query.OrderByDescending(listing => listing.ListingTime);
                    break;
            }

            Listings = query.ToList();
            Categories = new SelectList(_dbContext.Categories.Select(c => c.CategoryName).Distinct());

            return Page();
        }
    }
}