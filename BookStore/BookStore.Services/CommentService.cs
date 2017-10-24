using System;
using System.Linq;
using BookStore.Data.Model;
using BookStore.Data.Repositories;
using BookStore.Data.Repositories.SaveContext;
using Bytes2you.Validation;


namespace BookStore.Services
{
    public class CommentService : ICommentService
    {
        private readonly IEfRepository<Comment> comments;
        private readonly IEfRepository<User> users;
        private readonly ISaveContext context;

        public CommentService(IEfRepository<Comment> comments, IEfRepository<User> users, ISaveContext context)
        {
            Guard.WhenArgument(comments, "comments").IsNull().Throw();
            Guard.WhenArgument(users, "users").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.comments = comments;
            this.users = users;
            this.context = context;

        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All()
                .OrderBy(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetById(Guid commentId)
        {
            return this.comments
                .All()
                .Where(c => c.Id == commentId);

        }

        public Comment GetCommentByUserId(Guid userId)
        {
            return this.comments
                .All()
                .Where(c => c.UserId == userId.ToString())
                .FirstOrDefault();
        }

        public Comment AddComment(string content, string userId, Guid bookId)
        {
            var user = users.All().Where(u => u.Id == userId).FirstOrDefault();

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
