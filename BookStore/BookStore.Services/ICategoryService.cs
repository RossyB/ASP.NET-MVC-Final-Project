using System;
using System.Linq;
using BookStore.Data.Model;
using BookStore.Services.Contracts;

namespace BookStore.Services
{
    public interface ICategoryService : IService
    {
        IQueryable<Category> GetAll();
        IQueryable<Category> GetById(Guid categoryId);
        Category GetCategoryByName(string name);
    }
}