using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models.DAL;
using Microsoft.AspNetCore.Http;
using QwikThrift.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QwikThrift.Pages.MyListings
{
    public class CreateModel : PageModel
    {
        private readonly QwikThriftDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateModel(QwikThriftDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Listing Listing { get; set; }
        public SelectList Categories { get; set; }
       

        public IActionResult OnGet()
        {
            var userMan = new UserManager(_httpContextAccessor.HttpContext.Session, _dbContext);

            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }
            
            // Create a new Listing with pre-filled values
            Listing = new Listing
            {
                Owner = userMan.User,          //Set User Name
                OwnerId = userMan.User.UserId, //Set User ID
                SaleStatus = false // Set SaleStatus to false
            };
            Categories = new SelectList(_dbContext.Categories.Select(c => c.CategoryName).Distinct());
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return to the page with validation errors.
                return Page();
            }
            
            _dbContext.Listings.Add(Listing);
            _dbContext.SaveChanges();

            return RedirectToPage("/MyListings/Index");
        }
    }
}