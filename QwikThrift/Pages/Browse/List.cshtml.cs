using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QwikThrift.Models.DAL;

namespace QwikThrift.Pages.Browse
{
    public class ListModel : PageModel
    {
        private readonly QwikThrift.Models.DAL.QwikThriftDbContext _context;

        public ListModel(QwikThrift.Models.DAL.QwikThriftDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories
                .Include(c => c.AuthorizedBy).ToListAsync();
            }
        }
    }
}
