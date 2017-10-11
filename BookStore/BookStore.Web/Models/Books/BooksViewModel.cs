using AutoMapper;
using BookStore.Data.Model;
using BookStore.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Models.Books
{
    public class BooksViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public BooksViewModel()
        {

        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        [DisplayName("Book Image Url")]
        public string BookImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public string OwnerEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
              configuration.CreateMap<Book, BooksViewModel>()
                    .ForMember(x => x.CategoryId, cfg => cfg.MapFrom(y => y.Category.Id))
                    .ForMember(x => x.CategoryName, cfg => cfg.MapFrom(y => y.Category.Name))
                    .ForMember(x => x.OwnerEmail, cfg => cfg.MapFrom(y => y.Owner.Email));
        }
    }
}