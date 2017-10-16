using AutoMapper;
using BookStore.Data.Model;
using BookStore.Services;
using BookStore.Web.Models.Comments;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IBookService bookService;

        public CommentsController(ICommentService commentService, IBookService bookService)
        {
            this.commentService = commentService;
            this.bookService = bookService;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult BookComment(BookCommentViewModel comment)
        {
            var currentUserId = User.Identity.GetUserId();
            var newComment = this.commentService.AddComment(
                comment.Content,
                currentUserId,
                comment.BookId);

            var viewModel = Mapper.Map<CommentViewModel>(newComment);

            return PartialView("_CommentPartial", viewModel);
        }
    }
}