using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksTracker.Pages.Models
{
    public class Category
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Type { get; set; }
        public string Name { get; set; }

        public List<CategoryType> CategoryTypes { get; set; }

    }
}
