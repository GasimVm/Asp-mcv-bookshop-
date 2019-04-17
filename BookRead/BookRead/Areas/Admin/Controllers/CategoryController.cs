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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private readonly BookContext _context;
        public CategoryController()
        {
            _context = new BookContext();
        }
        public ActionResult Index()
        {

            return View(_context.Categories.ToList());
        }
        public ActionResult Edit(int Id)
        {
            return View(_context.Categories.Find(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (category.Name == null) return View(category);
            var categorydb = _context.Categories.Where(p => p.Id == category.Id).First();
            categorydb.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Category category = _context.Categories.Find(Id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Id")] Category category)
        {
            if (category.Name == null) return View(category);
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
