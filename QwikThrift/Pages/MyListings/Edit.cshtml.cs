#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QwikThrift.Models.DAL;
using System.Threading.Tasks;


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

            // Retrieve the listing by ID from the database
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

            // Update the listing in the database
            _context.Attach(Listing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(Listing.ListingId))
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

        private bool ListingExists(int id)
        {
            return _context.Listings.Any(e => e.ListingId == id);
        }
    }
}
