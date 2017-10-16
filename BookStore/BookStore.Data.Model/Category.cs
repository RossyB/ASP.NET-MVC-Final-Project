using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Data.Model.Abstracts;
using BookStore.Common;

namespace BookStore.Data.Model
{
    public class Category : DataModel
    {
        private ICollection<Book> books;

        public Category()
        {
            this.books = new HashSet<Book>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.CategoryMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.CategoryMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        public string Name { get; set; }


        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}

