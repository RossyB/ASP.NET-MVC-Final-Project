using BookStore.Services;
using BookStore.Web.Infrastructure;
using BookStore.Web.Models.Books;
using BookStore.Web.Models.Home;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;


        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = this.bookService
                .GetAll()
                .MapTo<BooksViewModel>()
                .ToList();

            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BooksViewModel book)
        {
            var currentUserId = User.Identity.GetUserId();

            var newBook = this.bookService.AddBook(
                book.Title,
                book.Author,
                book.Description,
                book.Price,
                book.BookImageUrl,
                book.CategoryId,
                currentUserId);

            return RedirectToAction("Index", "Books");
        }

    }
}