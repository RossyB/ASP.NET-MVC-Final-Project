using BookStore.Services;
using BookStore.Web.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getCategories()
        {
            var categories = categoryService.GetAll()
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString()})
                .ToList();

            
            return View(categories);
        }
    }
}