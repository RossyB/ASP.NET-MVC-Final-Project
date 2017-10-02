using Microsoft.AspNet.Identity.EntityFramework;
using BookStore.Data.Model;

namespace BookStore.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}
