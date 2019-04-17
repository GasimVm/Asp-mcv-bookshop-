using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookRead.Models;

namespace BookRead.DAL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookShopContext")
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBooks> CategoryBooks { get; set; }

    }
    }
