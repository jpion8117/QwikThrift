using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QwikThrift.Models.DAL;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using QwikThrift.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace QwikThrift.Pages.MyListings
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly QwikThriftDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateModel(QwikThriftDbContext dbContext, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Listing Listing { get; set; } = default!;

        public SelectList Categories { get; set; }

        [BindProperty]
        public string Category {  get; set; }
        
        [BindProperty]
        public List<IFormFile> FormFiles { get; set; } = new List<IFormFile> { };

        public IActionResult OnGet()
        {
            var userMan = new UserManager(HttpContext.Session, _dbContext);

            if (!userMan.UserLoggedIn)
            {
                return RedirectToPagePermanent("/Users/Login", new { returnUrl = Request.GetEncodedUrl() });
            }
            ViewData["CategoryId"] = new SelectList(_dbContext.Categories, "CategoryId", "CategoryId");

            
            Listing = new Listing
            {
                Owner = userMan.User,          //Set User Name
                SaleStatus = false // Set SaleStatus to false
            };
            Categories = new SelectList(_dbContext.Categories.Select(c => c.CategoryName).Distinct());
            return Page();
        }

        public IActionResult OnPost()
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            List<string> filePaths = new List<string>();
            if (!ModelState.IsValid)
            {
                // If model validation fails, return to the page with validation errors.
                return Page();
            }

            //get Id of current user from user manager and store it in the Listing
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            if (!userMan.UserLoggedIn)
                return RedirectToPage("/AccessDenied");

            if (userMan.User != null)
                Listing.OwnerId = userMan.User.UserId;
            else
                throw new ArgumentNullException(nameof(userMan.User));

            Listing.ListingTime = DateTime.Now;

            //lookup category in database and store its ID in the listing
            var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryName == Category);
            if (category != null)
                Listing.CategoryId = category.CategoryId;

            _dbContext.Listings.Add(Listing);
            _dbContext.SaveChanges();
            
            foreach (var file in FormFiles)
            {
                string filename = Listing.Owner.Username.Replace(' ', '_') + '_' + Listing.Title.Replace(' ', '_') + '_' + 
                    DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
                string path = "\\images\\listingsInDev\\" + Listing.ListingId.ToString() + "\\";

                var imageReference = new ImageReference();

                imageReference.Name = filename;
                imageReference.Path = path;
                imageReference.Description = $"Image from listing \"{Listing.Title}\""; 
                imageReference.Filename = filename;
                imageReference.ListingId = Listing.ListingId;
                imageReference.ImageFile = file;

                if (imageReference.SaveImageToFile())
                    _dbContext.ImageReferences.Add(imageReference);
                else
                    throw new Exception("File failed to save to disk.");
            }

            _dbContext.SaveChanges();

            return RedirectToPage("/MyListings/Index");
        }
    }
}

