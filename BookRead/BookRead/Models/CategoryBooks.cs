using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRead.Models
{
    public class CategoryBooks
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }


    }
}