using BookStore.Data.Model;
using BookStore.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;

namespace BookStore.Web.Models.Books
{
    public class CategoriesViewModel : IMapFrom<Category>
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
    }
}