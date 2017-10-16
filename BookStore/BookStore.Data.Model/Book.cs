using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookStore.Common;
using BookStore.Data.Model.Abstracts;

namespace BookStore.Data.Model
{
    public class Book : DataModel
    {
        private ICollection<Comment> comments;

        public Book()
        {
            this.comments = new HashSet<Comment>();
        }

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
        public string BookImageUrl { get; set; }

        [Range(typeof(int),
            ValidationConstants.BookRatingMinValue,
            ValidationConstants.BookRatingMaxValue, ErrorMessage = ValidationConstants.RatingOutOfRangeErrorMessage)]
        public int Rathing { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
