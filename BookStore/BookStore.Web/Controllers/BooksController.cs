using BookStore.Services;
using BookStore.Web.Infrastructure;
using BookStore.Web.Models.Books;
using BookStore.Web.Models.Comments;
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
        private readonly ICommentService commentService;

        public BooksController(IBookService bookService, ICategoryService categoryService, ICommentService commentService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.commentService = commentService;
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

        public ActionResult BookDetails(string Id)
        {
            var book = this.bookService
                .GetById(Guid.Parse(Id))
                .MapTo<BookDetailViewModel>()
                .FirstOrDefault();
            
            book.Comments = commentService.GetAll()
                .Where(c => c.BookId == book.Id)
                .MapTo<CommentViewModel>()
                .ToList();

            return View(book);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddBook()
        {


            var model = new BooksViewModel
            {
                Categories = GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
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