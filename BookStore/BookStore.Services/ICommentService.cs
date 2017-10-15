using System;
using System.Linq;
using BookStore.Data.Model;
using BookStore.Services.Contracts;

namespace BookStore.Services
{
    public interface ICommentService : IService
    {
        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetById(Guid commentId);

        Comment GetCommentByUserId(Guid userId);

        Comment AddComment(string content, string userId, Guid bookId);
    }
}