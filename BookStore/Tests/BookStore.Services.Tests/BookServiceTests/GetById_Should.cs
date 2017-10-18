using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Services.Tests.BookServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnProduct_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();
            var bookId =Guid.NewGuid();

            bookRepositoryMock.Setup(m => m.GetById(bookId)).Returns(new Book() { Id = bookId });

            BookService bookService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Act
            var book = bookService.GetById(bookId);

            // Assert
            Assert.IsNotNull(book);
        }
    }
}
