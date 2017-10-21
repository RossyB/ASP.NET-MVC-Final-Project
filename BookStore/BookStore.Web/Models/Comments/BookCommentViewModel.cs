using BookStore.Data.Model;
using BookStore.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using BookStore.Common;

namespace BookStore.Web.Models.Comments
{
    public class BookCommentViewModel: IMapFrom<Comment>
    {
        public BookCommentViewModel()
        {
        }

        public BookCommentViewModel(Guid bookId)
        {
            this.BookId = bookId;
        }

        public Guid BookId { get; set; }

        [Required]
        [MinLength(ValidationConstants.CommentContentMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.CommentContentMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

    }
}