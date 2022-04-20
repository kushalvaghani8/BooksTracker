using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using schema = Schema.NET;

namespace BooksTracker.Pages.Models
{
 
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        public string CategoryTypeName { get; set; }

        public CategoryType CategoryType { get; set; }


        public schema.Thing GetJson()
        {
            schema.Book book = new schema.Book();

            book.Isbn = this.ISBN;
            book.Name = this.Title;
            book.Author = new schema.Person() { Name = this.Author };



            //blog.About = new schema.OneOrMany<schema.IThing>(new List<schema.Thing>() { new schema.Thing() { Name = this.Description } });
            //blog.Url = this.Url;
            //blog.Name = this.Name;

            return book;
        }



    }
}
