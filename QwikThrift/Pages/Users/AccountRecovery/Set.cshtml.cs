using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Users.AccountRecovery
{
    public class SetModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;

        public SetModel(QwikThrift.Models.DAL.QwikThriftDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public UserSecurityQuestion UserSecurityQuestion { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SecurityQuestions == null || UserSecurityQuestion == null)
            {
                return Page();
            }

            _context.SecurityQuestions.Add(UserSecurityQuestion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
