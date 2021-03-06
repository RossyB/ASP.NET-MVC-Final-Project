﻿using BookStore.Data.Model;
using BookStore.Data.Repositories;
using BookStore.Data.Repositories.SaveContext;
using Bytes2you.Validation;
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
        private readonly ISaveContext context;

        public BookService(IEfRepository<Book> books, IEfRepository<User> users, ISaveContext context)
        {
            Guard.WhenArgument(books, "books").IsNull().Throw();
            Guard.WhenArgument(users, "users").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.books = books;
            this.users = users;
            this.context = context;
        }

        public IQueryable<Book> GetAll()
        {
            return this.books.All()
                .OrderBy(c => c.Title);
        }

        public IQueryable<Book> GetById(Guid? bookId)
        {
            return this.books
                .All()
                .Where(b => b.Id == bookId);

        }

        public Guid AddBook(string title, string author, string description, decimal? price, string bookImageUrl, Guid? categoryId, string userId)
        {
            var newBook = new Book()
            {
                Title = title,
                Author = author,
                Description = description,
                Price = (decimal)price,
                BookImageUrl = bookImageUrl,
                CreatedOn = DateTime.UtcNow,
                CategoryId = (Guid)categoryId,
                OwnerId = userId,
            };

            this.books.Add(newBook);
            this.context.Commit();

            return newBook.Id;
        }
    }
}
