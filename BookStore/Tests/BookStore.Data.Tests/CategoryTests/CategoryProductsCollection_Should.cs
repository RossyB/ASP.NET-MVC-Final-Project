using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Tests.CategoryTests
{
    public class CategoryProductsCollection_Should
    {
        [Test]
        public void GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid();
            var book = new Book() { Id = testId };
            var set = new HashSet<Book> { book };
            var category = new Category() { Books = set };

            // Assert
            Assert.AreEqual(category.Books.First().Id, testId);
        }
    }
}
