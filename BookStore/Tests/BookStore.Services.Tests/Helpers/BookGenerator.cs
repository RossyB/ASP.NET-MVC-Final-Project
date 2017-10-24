using BookStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Tests.Helpers
{
    public class BookGenerator
    {
        public static IEnumerable<Book> GetBooks(int count)
        {
            Random rng = new Random();

            var result = new List<Book>(count);

            for (int i = 0; i < count; i++)
            {
                var book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = StringGenerator.RandomString(rng.Next(50)),
                    Author = StringGenerator.RandomString(rng.Next(50)),
                    Description = StringGenerator.RandomString(rng.Next(50)),
                    Price = rng.Next(),
                    BookImageUrl = StringGenerator.RandomString(rng.Next(50)),
                    Rathing = 0
                };

                result.Add(book);
            }

            return result;
        }
    }
}
