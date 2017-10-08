using System;
using System.Linq;
using BookStore.Data.Model;

namespace BookStore.Services
{
    public interface IBookService
    {
        IQueryable<Book> GetAll();
        IQueryable<Book> GetById(Guid bookId);
        Guid AddBook(string title, string author, string description, decimal price, string bookImageUrl, Guid categoryId, string userId);
    }
}