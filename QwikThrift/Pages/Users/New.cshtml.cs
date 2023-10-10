#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QwikThrift.Models;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Users
{
    public class NewModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;

        [BindProperty]
        public CreateUser NewUser { get; set; }

        public NewModel(QwikThrift.Models.DAL.QwikThriftDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Users == null)
            {
                return Page();
            }

            var user = new User 
            {
                Username = NewUser.Username,
                Email = NewUser.Email,
                Password = NewUser.Password,
                Role = UserRoles.User
            };

            var duplicateUser = _context.Users.Where(u => u.Username == user.Username).FirstOrDefault();

            if (duplicateUser != null) 
            {
                ModelState.AddModelError("NewUser.Username", $"Username \"{NewUser.Username}\" is already taken," +
                    "please pick a different username to continue.");

                return Page();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
    }
}
