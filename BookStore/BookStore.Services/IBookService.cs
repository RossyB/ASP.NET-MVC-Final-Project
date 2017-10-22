using System;
using System.Linq;
using BookStore.Data.Model;
using BookStore.Services.Contracts;

namespace BookStore.Services
{
    public interface IBookService : IService
    {
        IQueryable<Book> GetAll();
        IQueryable<Book> GetById(Guid? bookId);
        Guid AddBook(string title, string author, string description, decimal? price, string bookImageUrl, Guid? categoryId, string userId);
    }
}