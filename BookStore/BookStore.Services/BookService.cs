using BookStore.Data.Model;
using BookStore.Data.Repositories;
using BookStore.Data.Repositories.SaveContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IEfRepository<Book> books;
        private readonly IEfRepository<User> users;
        private readonly IEfRepository<Category> categories;
        private readonly ISaveContext context;

        public BookService(IEfRepository<Book> books, IEfRepository<User> users, IEfRepository<Category> categories, ISaveContext context)
        {
            this.books = books;
            this.users = users;
            this.context = context;
            this.categories = categories;
        }

        public IQueryable<Book> GetAll()
        {
            return this.books.All
                .OrderBy(c => c.Title);
        }

        public IQueryable<Book> GetById(Guid bookId)
        {
            return this.books
                .All
                .Where(b => b.Id == bookId);

        }

        public Guid AddBook(string title, string author, string description, decimal price, string bookImageUrl, Guid categoryId, string userId)
        {
            var currentUser = this.users
                .All
                .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var newBook = new Book()
            {
                Title = title,
                Author = author,
                Description = description,
                Price = price,
                BookImageUrl = bookImageUrl,
                CreatedOn = DateTime.UtcNow,
                CategoryId = categoryId,
                OwnerId = userId,
            };

            this.books.Add(newBook);
            this.context.Commit();

            return newBook.Id;
        }
    }
}
