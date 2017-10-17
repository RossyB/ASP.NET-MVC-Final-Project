using System.Linq;
using BookStore.Data.Model.Contracts;
using System;

namespace BookStore.Data.Repositories
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }
        T GetById(Guid id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}