using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using BookStore.Data.Repositories.SaveContext;
using BookStore.Data;
using System;

namespace BookStore.Services.Tests.BookServiceTests
{
    [TestFixture]
    public class AddBook_Sould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenBookIsNull()
        {
            //Arange
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var validDbContext = new Mock<MsSqlDbContext>();
            var mockedSaveChanges = new Mock<SaveContext>(validDbContext.Object);

            //Act
            var bookService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, mockedSaveChanges.Object);

            //Assert
            Assert.That(() => bookService.AddBook(null, null, null, null, null, null, null),
                            Throws.InvalidOperationException);
        }

        //[Test]
        //public void CallBooksRepositoryAddMethodWhenBookParameterIsValid()
        //{
            // Arrange
        //    var userId = Guid.NewGuid();
        //    var testGuid = Guid.NewGuid();
        //    var bookRepositoryMock = new Mock<IEfRepository<Book>>();
        //    var userRepositoryMock = new Mock<IEfRepository<User>>();
        //    var validDbContext = new Mock<MsSqlDbContext>();
        //    var mockedSaveChanges = new Mock<SaveContext>(validDbContext.Object);
        //    var mockedBook = new Mock<Book>();


            // Act
        //    var booksService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, mockedSaveChanges.Object);
        //    booksService.AddBook("Title", "Author", "Description", (Decimal)2.30, "asdfghjkl", testGuid, userId.ToString());

        //    bookRepositoryMock.Verify(x => x.Add(mockedBook.Object), Times.Once());
        //}

        //[Test]
        //public void CallSaveChangesOnce_IfAdvertIsValid()
        //{
            // Arrange
        //    var userId = Guid.NewGuid();
        //    var testGuid = Guid.NewGuid();
        //    var bookRepositoryMock = new Mock<IEfRepository<Book>>();
        //    var userRepositoryMock = new Mock<IEfRepository<User>>();
        //    var validDbContext = new Mock<MsSqlDbContext>();
        //    var mockedSaveChanges = new Mock<SaveContext>(validDbContext.Object);
          
            // Act
        //    var booksService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, mockedSaveChanges.Object);
        //    booksService.AddBook("Title", "Author", "Description", (Decimal)2.30, "asdfghjkl", testGuid, userId.ToString());

            // Assert
        //   mockedSaveChanges.Verify(ser => ser.Commit(), Times.Once);
        //}

    }
}
