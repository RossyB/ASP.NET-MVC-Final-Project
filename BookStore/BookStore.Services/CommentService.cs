﻿using BookStore.Data.Model;
using BookStore.Data.Repositories;
using BookStore.Data.Repositories.SaveContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CommentService : ICommentService
    {
        private readonly IEfRepository<Comment> comments;
        private readonly IEfRepository<User> users;
        private readonly ISaveContext context;

        public CommentService(IEfRepository<Comment> comments, IEfRepository<User> users, ISaveContext context)
        {
            this.comments = comments;
            this.users = users;
            this.context = context;

        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All
                .OrderBy(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetById(Guid commentId)
        {
            return this.comments
                .All
                .Where(c => c.Id == commentId);

        }

        public Comment GetCommentByUserId(Guid userId)
        {
            return this.comments
                .All
                .Where(c => c.UserId == userId.ToString())
                .FirstOrDefault();
        }

        public Comment AddComment(string content, string userId, Guid bookId)
        {
            var user = users.All.Where(u => u.Id == userId).FirstOrDefault();

            var newComment = new Comment()
            {
                Content = content,
                UserId = userId,
                User = user,
                BookId = bookId,
                CreatedOn = DateTime.UtcNow,
            };

            this.comments.Add(newComment);
            this.context.Commit();

            return newComment;
        }
    }
}