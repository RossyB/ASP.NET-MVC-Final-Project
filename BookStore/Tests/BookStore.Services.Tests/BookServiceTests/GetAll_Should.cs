using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using BookStore.Data.Repositories.SaveContext;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Services.Tests.BookServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void BeCalled_WhenParamsAreValid()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();
            
            BookService bookService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Act
            bookService.GetAll();

            // Assert
            bookRepositoryMock.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();


            // Assert
            bookRepositoryMock.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            BookService bookService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Act
            var expectedbookResult = new List<Book>() { new Book(), new Book() };
            bookRepositoryMock.Setup(rep => rep.All()).Returns(() => expectedbookResult.AsQueryable());

            // Assert
            Assert.AreEqual(bookService.GetAll(), expectedbookResult);
        }

    }
}
