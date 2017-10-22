using System.Data.Entity;
using BookStore.Data.Model;

namespace BookStore.Data
{
    public interface IMsSqlDbContext
    {
        IDbSet<Book> Books { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Comment> Comments { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}