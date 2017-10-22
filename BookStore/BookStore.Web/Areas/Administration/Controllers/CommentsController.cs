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
    public class CommentsController : Controller
    {
        private readonly IEfRepository<Comment> comments;
        private readonly IEfRepository<User> users;
        private readonly IEfRepository<Book> books;
        private readonly ISaveContext context;

        public CommentsController(IEfRepository<Comment> comments, IEfRepository<User> users, IEfRepository<Book> books, ISaveContext context)
        {
            this.comments = comments;
            this.users = users;
            this.books = books;
            this.context= context;
        }

        // GET: Administration/Comments
        public ActionResult Index()
        {
            var commentsList = comments.All().ToList();
            return View(commentsList);
        }

        // GET: Administration/Comments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = comments.All().Where(c=> c.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Administration/Comments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = comments.All().Where(c => c.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(books.All(), "Id", "Title", comment.BookId);
            ViewBag.UserId = new SelectList(users.All(), "Id", "FirstName", comment.UserId);
            return View(comment);
        }

        // POST: Administration/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,UserId,BookId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comments.Update(comment);
                context.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(books.All(), "Id", "Title", comment.BookId);
            ViewBag.UserId = new SelectList(users.All(), "Id", "FirstName", comment.UserId);
            return View(comment);
        }

        // GET: Administration/Comments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = comments.All().Where(c => c.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Administration/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Comment comment = comments.All().Where(c => c.Id == id).FirstOrDefault();
            comments.Delete(comment);
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}
