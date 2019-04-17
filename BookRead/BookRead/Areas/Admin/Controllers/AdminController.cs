using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookRead.AdminAtuhen;
using System.Web.Helpers;
using BookRead.Models;
using BookRead.DAL;
using BookRead.Extentions;
using static BookRead.Utilities.Utilite;

namespace BookRead.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly BookContext _context;
        public AdminController()
        {
            _context = new BookContext();
            ViewBag.Data = _context.Authors.ToList();
            ViewBag.Category = _context.Categories.ToList();
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string password, string username)
        {
            if (password == "admin" && username == "admin") {
                Session["admin"] = true;

            }

            return RedirectToAction("About");
        }
        [AdminAnthunetion]
        public ActionResult About()
        {
            var model = _context.Books;
            return View(model);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Page,Description,Price,Title,Photo,PdfLink")] Book book, int[] checkAuthor, int[] selectCategories)
        {

            if (!ModelState.IsValid) return View();
            if (checkAuthor.Length > 0) {
                foreach (var item in checkAuthor)
                {
                    book.Authors.Add(_context.Authors.Find(item));
                }
            }

            if (selectCategories.Length > 0) {
                foreach (var item in selectCategories)
                {
                    var category = new CategoryBooks()
                    {
                         CategoryId = item,
                         BookId=book.Id
                    };
                    _context.CategoryBooks.Add(category);
                }
                
            }



            if (book.Photo == null) { return View(book); }
            if (!book.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Choose Photo is valid");
                return View(book);
            }
            book.Image = book.Photo.SaveFiles("Images");
            if (book.PdfLink == null)
            {
                ModelState.AddModelError("PdfLink", "Please choose is file ");
                return View(book);
            }
            if (!book.PdfLink.IsPdf())
            {
                ModelState.AddModelError("PdfLink", "Choose file is valid");
                return View(book);
            }
            book.Pdf = book.PdfLink.SaveFiles("Pdf");
            book.Date = DateTime.Now;

            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("About");
        }
        public ActionResult Edit(string Id)
        {
            
            var _id = Convert.ToInt32(Id);
            return View(_context.Books.Find(_id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Page,Description,Price, Title,Photo,PdfLink,Id")] Book book, int[] category, int[] authors)
        {
            if (!ModelState.IsValid) return View(book);

            var bookdb = _context.Books.Where(p => p.Id == book.Id).First();
            bookdb.Authors.Clear();
            
            if (  authors!=null) {
                foreach (var item in authors)
                {
                    bookdb.Authors.Add(_context.Authors.Find(item));
                }
            }
            if (category != null  ) {
                foreach (var item in category)
                {
                    var categorydb = new CategoryBooks()
                    {
                        CategoryId = item,
                        BookId = book.Id
                    };
                    _context.CategoryBooks.Remove(categorydb);
                }
            }

            if (book.Photo != null)
            {
                if (!book.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is invalid");
                    book.Image = bookdb.Image;
                    return View(book);
                }
                RemoveFile(bookdb.Image);

                bookdb.Image = book.Photo.SaveFiles("Images");
            }
            if (book.PdfLink != null)
            {
                if (!book.PdfLink.IsPdf())
                {
                    ModelState.AddModelError("Photo", "Photo type is invalid");
                    book.Pdf = bookdb.Pdf;
                    return View(book);
                }
                RemoveFile(bookdb.Pdf);

                bookdb.Pdf = book.PdfLink.SaveFiles("Pdf");
            }
            bookdb.Date = DateTime.Now;
            bookdb.Title = book.Title;
            bookdb.Description = book.Description;
            bookdb.Name = book.Name;
            bookdb.Price = book.Price;
            bookdb.Page = book.Page;
            _context.SaveChanges();




            return RedirectToAction("About");
        }
        public ActionResult Delete(int Id)
        {
            Book book = _context.Books.Find(Id);

            RemoveFile(book.Image);


            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("About");  

        }
         
        

    }
}