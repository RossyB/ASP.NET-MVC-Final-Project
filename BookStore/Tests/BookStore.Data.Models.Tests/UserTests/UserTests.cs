using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Models.Tests.UserTests
{
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldHaveParametlessConstructor()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void Constructor_ShouldInitializeBooksCollectionCorreclty()
        {
            // Arrange & Act
            var user = new User();
            var contactInfos = user.Books;

            // Assert
            Assert.That(contactInfos, Is.Not.Null.And.InstanceOf<HashSet<Book>>());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var user = new User { IsDeleted = testIsDeleted };

            // Assert
            Assert.AreEqual(testIsDeleted, user.IsDeleted);
        }

        [Test]
        public void BooksCollection_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid();
            var book = new Book() { Id = testId };
            var set = new HashSet<Book> { book };
            var user = new User() { Books = set };

            // Assert
            Assert.AreEqual(user.Books.First().Id, testId);
        }

        [Test]
        public void Users_ShouldGetAndSetFirstNameCorrectly()
        {
            // Arrange & Act
            var user = new User();
            var firstName = "Pesho";
            user.FirstName = firstName;

            // Assert
            Assert.AreEqual(user.FirstName, firstName);
        }

        [Test]
        public void Users_ShouldGetAndSetLastNameCorrectly()
        {
            // Arrange & Act
            var user = new User();
            var lastName = "Peshev";
            user.LastName = lastName;

            // Assert
            Assert.AreEqual(user.LastName, lastName);
        }

        [Test]
        public void Users_ShouldGetAndSetImageUrlCorrectly()
        {
            // Arrange & Act
            var user = new User();
            var imageUrl = "http://abv.bg";
            user.ImageUrl = imageUrl;

            // Assert
            Assert.AreEqual(user.ImageUrl, imageUrl);
        }
    }
}
