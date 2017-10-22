using System;
using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Tests.BookTests
{
    [TestFixture]
    public class BookOwner_Should
    {
        [Test]
        public void CategoryId__GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid().ToString();
            var book = new Book { OwnerId = testId };

            // Assert
            Assert.AreEqual(book.OwnerId, testId);
        }

        [TestCase("PeshoP")]
        public void Category_Should_GetAndSetDataCorrectly(string testOwnerName)
        {
            // Arrange & Act         
            var user = new User() { UserName = testOwnerName };
            var book = new Book { Owner = user };

            // Assert
            Assert.AreEqual(book.Owner.UserName, testOwnerName);
        }
    }
}
