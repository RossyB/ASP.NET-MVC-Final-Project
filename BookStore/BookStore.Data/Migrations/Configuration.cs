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
        const string AdminUserName = "admin@bookstore.com";
        const string AdminPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedSampleData(context);
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
                var user = new User { UserName = AdminUserName, Email = AdminUserName, EmailConfirmed = true};
                userManager.Create(user, AdminPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
        private void SeedSampleData(MsSqlDbContext context)
        {
            if (!context.Books.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var book = new Book()
                    {
                        Title = "Book " + i,
                        Author = "Alabala" + i,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet lobortis nibh. Nullam bibendum, tortor quis porttitor fringilla, eros risus consequat orci, at scelerisque mauris dolor sit amet nulla. Vivamus turpis lorem, pellentesque eget enim ut, semper faucibus tortor. Aenean malesuada laoreet lorem.",
                        Price = 8,
                        Category = new Category { Name = "Category" + i },
                        Owner = context.Users.First(x => x.Email == AdminUserName),
                        CreatedOn = DateTime.Now
                    };

                    context.Books.Add(book);
                }
            }
        }
    }
}
