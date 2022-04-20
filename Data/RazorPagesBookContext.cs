using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksTracker.Pages.Models;

    public class RazorPagesBookContext : DbContext
    {
        public RazorPagesBookContext (DbContextOptions<RazorPagesBookContext> options)
            : base(options)
        {
        }

        public DbSet<BooksTracker.Pages.Models.Book> Book { get; set; }
        public DbSet<BooksTracker.Pages.Models.Category> Category { get; set; }
        public DbSet<BooksTracker.Pages.Models.CategoryType> CategoryType { get; set; }
}
