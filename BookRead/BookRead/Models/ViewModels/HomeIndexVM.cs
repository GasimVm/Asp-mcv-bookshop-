using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRead.Models.ViewModels
{
    public class HomeIndexVM
    {
        
        public IEnumerable<Book> Book { get; set; }
        public IEnumerable<Author> Author { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<CategoryBooks> CategoryBooks { get; set; }

    }
}