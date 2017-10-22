using System;
using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Tests.Models.BookTests
{
    [TestFixture]
    public class BookCategory_Should
    {
        [Test]
        public void CategoryId__GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid();
            var book = new Book { CategoryId = testId };

            // Assert
            Assert.AreEqual(book.CategoryId, testId);
        }

        [TestCase("Music")]
        public void Category_Should_GetAndSetDataCorrectly(string testCategoryName)
        {
            // Arrange & Act         
            var category = new Category() { Name = testCategoryName };
            var book = new Book { Category = category };

            // Assert
            Assert.AreEqual(book.Category.Name, testCategoryName);
        }
    }
}
