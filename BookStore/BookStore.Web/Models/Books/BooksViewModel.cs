using AutoMapper;
using BookStore.Common;
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

        [Required]
        [MinLength(ValidationConstants.BookTitleMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.BookTitleMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.BookAuthorMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.BookAuthorMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        public string Author { get; set; }

        [MinLength(ValidationConstants.BookDescriptionMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.BookDescriptionMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal),
            ValidationConstants.BookPriceMinValue,
            ValidationConstants.BookPriceMaxValue, ErrorMessage = ValidationConstants.PriceOutOfRangeErrorMessage)]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }

        [MinLength(ValidationConstants.BookImageUrlMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.BookImageUrlMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [DisplayName("Book Image Url")]
        public string BookImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public string OwnerUserName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
              configuration.CreateMap<Book, BooksViewModel>()
                    .ForMember(x => x.CategoryId, cfg => cfg.MapFrom(y => y.Category.Id))
                    .ForMember(x => x.CategoryName, cfg => cfg.MapFrom(y => y.Category.Name))
                    .ForMember(x => x.OwnerUserName, cfg => cfg.MapFrom(y => y.Owner.UserName));
        }
    }
}