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
    public class CreateCategoryTypeModel : PageModel
    {
        private readonly RazorPagesBookContext _context;

        public CreateCategoryTypeModel(RazorPagesBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryType.Add(CategoryType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
