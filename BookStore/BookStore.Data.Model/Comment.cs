using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Data.Model.Abstracts;
using BookStore.Common;

namespace BookStore.Data.Model
{
    public class Comment : DataModel
    {
        [Required]
        [MinLength(ValidationConstants.CommentContentMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.CommentContentMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        public string Content { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
