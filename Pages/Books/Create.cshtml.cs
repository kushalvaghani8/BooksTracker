using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksTracker.Pages.Models;

namespace BooksTracker.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesBookContext _context;

        public CreateModel(RazorPagesBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryTypeName"] = new SelectList(_context.CategoryType, "Name", "Name");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
