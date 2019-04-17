using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRead.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
            CategoryBooks = new HashSet<CategoryBooks>();
        }
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public int Page { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public double Price { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [StringLength(300)]
        public string Pdf { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public HttpPostedFileBase PdfLink { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        public virtual ICollection<Author> Authors { get; set; }         
        public virtual ICollection<CategoryBooks> CategoryBooks { get; set; }
    }
}