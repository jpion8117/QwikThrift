#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Browse
{
    public class CategoryDetailsModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;

        public CategoryDetailsModel(QwikThriftDbContext dataRepository)
        {
            _dbContext = dataRepository;
        }
        public Category Item { get; private set; }
        public IActionResult OnGet(int id)
        {
            // Retrieve the item based on the given Id from data repository
            Item = _dbContext.Categories.FirstOrDefault(item => item.CategoryId == id);

            if (Item == null)
            {
                return NotFound(); // Handle item not found
            }

            return Page();
        }
    }
}