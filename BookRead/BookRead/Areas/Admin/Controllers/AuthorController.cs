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
    [AdminAnthunetion]
    public class AuthorController : Controller
    {
        // GET: Admin/Author
        private readonly BookContext _context;
        public AuthorController()
        {
            _context = new BookContext();
        }
        public ActionResult Index()
        {

            return View(_context.Authors.ToList());
        }
        public ActionResult Edit(int Id)
        {
            return View(_context.Authors.Find(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include ="Id,Name")] Author author)
        {
            if (author.Name==null) return View(author);
            var authordb = _context.Authors.Where(p => p.Id == author.Id).First();
            authordb.Name = author.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Author author = _context.Authors.Find(Id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Create( )
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,Id")] Author author)
        {
            if (author.Name == null) return View(author);
            _context.Authors.Add(author);
            _context.SaveChanges();
            
            return RedirectToAction("Index");

        }
    }
}