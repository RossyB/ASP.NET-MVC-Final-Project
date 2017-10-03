using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookStore.Data.Model;

namespace BookStore.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            const string AdminUserName = "admin@bookstore.com";
            const string AdminPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdminUserName, Email = AdminUserName, EmailConfirmed = true};
                userManager.Create(user, AdminPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
