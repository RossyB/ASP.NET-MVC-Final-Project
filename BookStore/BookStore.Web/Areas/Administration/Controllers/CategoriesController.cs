using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Data;
using BookStore.Data.Model;
using BookStore.Data.Repositories;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Web.Areas.Administration.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IEfRepository<Category> categories;
        private readonly IEfRepository<User> users;
        private readonly IEfRepository<Book> books;
        private readonly ISaveContext context;

        public CategoriesController(IEfRepository<Category> categories, IEfRepository<User> users, IEfRepository<Book> books, ISaveContext context)
        {
            this.categories = categories;
            this.users = users;
            this.books = books;
            this.context = context;
        }
        // GET: Administration/Categories
        public ActionResult Index()
        {
            var categoriesList = categories.All.OrderBy(n => n.Name).ToList();

            return View(categoriesList);
        }

        // GET: Administration/Categories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categories.All.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Administration/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                category.CreatedOn = DateTime.Now;
                categories.Add(category);
                context.Commit();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Administration/Categories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categories.All.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Category category)
        {
            if (ModelState.IsValid)
            {
                categories.Update(category);
                context.Commit();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Administration/Categories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categories.All.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Category category = categories.All.Where(c => c.Id == id).FirstOrDefault();
            categories.Delete(category);
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}
