using BookStore.Data.Model;
using BookStore.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.Models.Books
{
    public class BookDetailViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string BookImageUrl { get; set; }

        public int Rathing { get; set; }

        public Guid CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public string OwnerUserName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, BooksViewModel>()
                    .ForMember(x => x.CategoryId, cfg => cfg.MapFrom(y => y.Category.Id))
                    .ForMember(x => x.OwnerUserName, cfg => cfg.MapFrom(y => y.Owner.UserName));
        }
    }
}