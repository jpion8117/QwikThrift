#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly QwikThriftDbContext _dbContext;
        public IndexModel(ILogger<IndexModel> logger, QwikThriftDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<Listing> LastFiveListings { get; set; }
        public void OnGet()
        {
            //provide UserManager access to the _dbContext
            var userMan = new UserManager(HttpContext.Session, _dbContext);

            // Retrieve the last 5 listings from the database
            LastFiveListings = _dbContext.Listings
                .OrderByDescending(listing => listing.ListingId)
                .Take(5)
                .ToList();
        }
    }
}