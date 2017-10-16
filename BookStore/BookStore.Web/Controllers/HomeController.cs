using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Services;
using BookStore.Web.Infrastructure;
using BookStore.Web.Models.Home;
using AutoMapper.QueryableExtensions;
using BookStore.Web.Models.Books;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            var books = this.bookService
                .GetAll()
                .ProjectTo<HomeBookViewModel>()
                .OrderByDescending(b => b.CreatedOn)
                .Take(8)
                .ToList();

            return View(books);
        }

        public ActionResult Books()
        {
            var books = this.bookService
                .GetAll()
                .ProjectTo<BooksViewModel>()
                .ToList();

            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}