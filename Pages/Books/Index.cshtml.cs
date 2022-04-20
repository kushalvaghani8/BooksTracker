using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using local = BooksTracker.Pages.Models;
using schema = Schema.NET;

namespace BooksTracker.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBookContext _context;

        public IndexModel(RazorPagesBookContext context)
        {
            _context = context;
        }


        /*

        getting the list for jsonld

        */
        public IList<local.Book> Book { get;set; }
        [BindProperty]
        public local.Book book { get; set; }
        public ICollection<schema.Thing> JSONLD
        { 
            get
            {
                List<schema.Thing> list = new List<schema.Thing>() { };
                foreach (var thing in GetBooksList()) { //passing booklist from the below method
                    list.Add(GetJson(thing));
                }
                return list;
            }
        }
        /*

           auto generated with scaffolding

        */

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.CategoryType).ToListAsync();
        }

        /*

        getting json for each book

         */

        public schema.Thing GetJson(local.Book Book) {

            schema.Book books = new schema.Book();
            books.Isbn = Book.ISBN;
            books.Author = new schema.Person() { Name = Book.Author };
            books.Name = Book.Title;

            return books;

        }


        /*

            

        */
        //passing the book list
        public List<local.Book> GetBooksList()
        {
            List<local.Book> BooksList = _context.Book 
                  .ToList();
            return BooksList;
        }


    }
}
