using System;
using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Models.Tests.BookTests
{
    [TestFixture]
    public class BookIsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var product = new Book { IsDeleted = testIsDeleted };

            // Assert
            Assert.AreEqual(testIsDeleted, product.IsDeleted);
        }
    }
}
