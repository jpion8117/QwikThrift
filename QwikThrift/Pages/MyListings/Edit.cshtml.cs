#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QwikThrift.Models.DAL;
using System;
using System.Threading.Tasks;
using QwikThrift.Models;

namespace QwikThrift.Pages.MyListings
{
    public class EditModel : PageModel
    {
        private readonly QwikThriftDbContext _context; 

        public EditModel(QwikThriftDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Listing Listing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Listing = await _context.Listings.FirstOrDefaultAsync(m => m.ListingId == id);

            if (Listing == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Listing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Listings.Any(e => e.ListingId == Listing.ListingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/MyListings/Index"); 
        }
    }
}
