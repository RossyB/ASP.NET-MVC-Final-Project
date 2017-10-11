using BookStore.Data.Model;
using BookStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfRepository<Category> categories;

        public CategoryService(IEfRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All
                .OrderBy(c => c.Name);
        }

        public IQueryable<Category> GetById(Guid categoryId)
        {
            return this.categories
                .All
                .Where(b => b.Id == categoryId);

        }

        public Category GetCategoryByName(string name)
        {
            return this.categories
                .All
                .Where(c => c.Name == name)
                .FirstOrDefault();
        }
    }
}
