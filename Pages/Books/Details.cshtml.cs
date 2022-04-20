using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksTracker.Pages.Models;

namespace BooksTracker.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesBookContext _context;

        public DetailsModel(RazorPagesBookContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.CategoryType).FirstOrDefaultAsync(m => m.ISBN == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
