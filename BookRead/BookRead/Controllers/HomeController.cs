using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookRead.Models.ViewModels;
using BookRead.Models;
using BookRead.DAL;


namespace BookRead.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context;
        public HomeController()
        {
            _context = new BookContext();
        }
        public ActionResult Index()
        {
            var vm = new HomeIndexVM()
            {
                Book=_context.Books,
                Category = _context.Categories,
                Author=_context.Authors,
                CategoryBooks=_context.CategoryBooks
            };
             
            return View(vm);
        }

        public ActionResult Details(int? Id)
        {
            Book book = _context.Books.Find(Id);

            return View(book);
        }

        public ActionResult AjaxSearch(string query)
        {
            List<Book> book = new List<Book>();

           book= _context.Books.Where(p => p.Name.Contains(query)).ToList();
            var vm = new HomeIndexVM()
            {
                Book = book,
                Category = _context.Categories,
                Author = _context.Authors,
                CategoryBooks = _context.CategoryBooks
            };

            if (book.Count > 0) return PartialView("_PartialAjaxSearch", vm);

            else
                return Content("Kitab tapilmadi!");
            
        }
    }
}