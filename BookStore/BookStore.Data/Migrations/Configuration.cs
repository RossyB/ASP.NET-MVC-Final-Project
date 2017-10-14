using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookStore.Data.Model;
using System;

namespace BookStore.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        const string AdminEmail = "admin@bookstore.com";
        const string AdminUserName = "Administrator";
        const string AdminPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedCategory(context);
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdminUserName, Email = AdminEmail, EmailConfirmed = true};
                userManager.Create(user, AdminPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
        private void SeedCategory(MsSqlDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new[] { "Biography", "Fantasy", "Health & Cookery", "History", "Home and Garden", "Horror", "Humour", "Kids Books", "Modern Fiction", "Philosophy & Psychology", "Sci-fi", "Science", "Sport", "Thrillers", "Travel", "Classics" };

                for (int i = 0; i < categories.Length; i++)
                {
                    var category = new Category()
                    {
                        Name =categories[i],
                        CreatedOn = DateTime.Now
                    };

                    context.Categories.Add(category);
                }
            }
        }
    }
}
