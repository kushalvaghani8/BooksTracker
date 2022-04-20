using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksTracker.Pages.Models
{
    public class CategoryType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string CategoryTypeCode { get; set; }

        public Category Category { get; set; }
        public List<Book> Books { get; set; }

    }
}
