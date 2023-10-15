using System;
using System.IO;
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
using Microsoft.AspNetCore.Hosting;

namespace QwikThrift.Pages.MyListings
{
    public class DeleteModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteModel(QwikThrift.Models.DAL.QwikThriftDbContext context, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
      public Listing Listing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Listings == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings.FirstOrDefaultAsync(m => m.ListingId == id);

            if (listing == null)
            {
                return NotFound();
            }
            else 
            {
                Listing = listing;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Listings == null)
            {
                return NotFound();
            }

            int listingIdToDeleteFilesFor = Listing.ListingId;
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            var listingToDelete = _context.Listings.FirstOrDefault(m => m.ListingId == id);
            if (listingToDelete != null)
            {
                listingToDelete.DeleteAssociatedImages();
                foreach(var image in listingToDelete.Images)
                {
                    _context.ImageReferences.Remove(image);
                }
            }
                
            var listing = await _context.Listings.FindAsync(id);

            if (listing != null)
            {
                Listing = listing;
                _context.Listings.Remove(Listing);
                NotificationBanner.SetBanner(HttpContext.Session, "Listing deleted successfully!", "bg-success text-white text-center");
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
