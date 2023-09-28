#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;

        public DetailsModel(QwikThriftDbContext dataRepository)
        {
            _dbContext = dataRepository;
        }
        public Listing Item { get; private set; }
        public string ReturnPage {  get; private set; }
        public string ReturnBtnLabel { get; private set; }
        public IActionResult OnGet(int id, string returnPage = "/Index", string returnBtnLable="Back to homepage.")
        {
            // Retrieve the item based on the given Id from data repository
            Item = _dbContext.Listings.FirstOrDefault(item => item.ListingId == id);
            ReturnPage = returnPage;
            ReturnBtnLabel = returnBtnLable;

            if (Item == null)
            {
                return NotFound(); // Handle item not found
            }

            return Page();
        }
    }
}
