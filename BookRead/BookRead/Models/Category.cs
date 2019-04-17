using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRead.Models
{
    public class Category
    {
        public Category()
        {
            CategoryBooks = new HashSet<CategoryBooks>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryBooks> CategoryBooks { get; set; }
 
    }
}