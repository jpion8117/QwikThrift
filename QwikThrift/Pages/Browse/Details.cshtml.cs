#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Browse
{
    public class DetailsModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;

        public DetailsModel(QwikThriftDbContext dataRepository)
        {
            _dbContext = dataRepository;
        }
        public Listing Item { get; private set; }
        public IActionResult OnGet(int id)
        {
            // Retrieve the item based on the given Id from data repository
            Item = _dbContext.Listings.FirstOrDefault(item => item.ListingId == id);

            if (Item == null)
            {
                return NotFound(); // Handle item not found
            }

            return Page();
        }
    }
}