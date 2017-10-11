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
        private readonly ICategoryService categoryService;

        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
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
            var model = new BooksViewModel
            {
                Categories = GetCategories()
            };

            return View(model);
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

        private IEnumerable<SelectListItem> GetCategories()
        {
            var categories = categoryService
                        .GetAll()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Name
                                });

            return new SelectList(categories, "Value", "Text");
        }


    }
}