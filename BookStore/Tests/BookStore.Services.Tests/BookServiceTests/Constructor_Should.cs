using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Services.Tests.BookServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenThreeParametersAreNotNull()
        {
            // Arrange 
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            BookService bookService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Assert
            Assert.That(bookService, Is.InstanceOf<BookService>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenBookRepositoryIsNull()
        {
            // Arrange
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new BookService(null, userRepositoryMock.Object, contextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserRepositoryIsNull()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new BookService(bookRepositoryMock.Object, null, contextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, null));
        }
    }
}
