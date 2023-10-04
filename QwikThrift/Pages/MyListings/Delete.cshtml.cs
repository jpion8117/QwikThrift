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

namespace QwikThrift.Pages.MyListings
{
    public class DeleteModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteModel(QwikThrift.Models.DAL.QwikThriftDbContext context)
        {
            _context = context;
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
            var listing = await _context.Listings.FindAsync(id);

            if (listing != null)
            {
                Listing = listing;
                _context.Listings.Remove(Listing);
                await _context.SaveChangesAsync();
            }

    
            int listingIdToDeleteFilesFor = Listing.ListingId; 
            string wwwRootPath = _webHostEnvironment.WebRootPath;
          
            var imageReferencesToDelete = _context.ImageReferences
                .Where(ir => ir.ListingId == listingIdToDeleteFilesFor)
                .ToList();

            foreach (var imageReference in imageReferencesToDelete)
            {
                string filePathToDelete = Path.Combine(wwwRootPath, imageReference.Path, imageReference.Name);

                // Create a FileInfo object
                FileInfo fileInfo = new FileInfo(filePathToDelete);

                // Check if the file exists and delete it
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                // Remove the ImageReference entity from the database context
                _context.ImageReferences.Remove(imageReference);
            }

            return RedirectToPage("./Index");
        }
    }
}
