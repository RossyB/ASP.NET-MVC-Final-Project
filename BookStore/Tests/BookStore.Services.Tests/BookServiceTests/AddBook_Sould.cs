using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using BookStore.Data.Repositories.SaveContext;
using BookStore.Data;
using System.Linq;

namespace BookStore.Services.Tests.BookServiceTests
{
    [TestFixture]
    public class AddBook_Sould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenBookIsNull()
        {
            var bookRepositoryMock = new Mock<IEfRepository<Book>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var validDbContext = new Mock<MsSqlDbContext>();
            var dbContextSaveChanges = new SaveContext(validDbContext.Object);

            var booksService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, dbContextSaveChanges);

            Assert.That(() => booksService.AddBook(null, null, null, null, null, null, null),
                            Throws.ArgumentException);
        }

        //[Test]
        //public void AddAdvert_Should_CallSaveChangesOnce_IfAdvertIsValid()
        //{
            // Arrange
        //    var userId = Guid.NewGuid();
        //    var testGuid = Guid.NewGuid();
        //    var UserDbModel = new User() { Id = userId.ToString(), UserName = "Ivancho"};
        //    var bookRepositoryMock = new Mock<IEfRepository<Book>>();
        //    var userRepositoryMock = new Mock<IEfRepository<User>>();
        //    var validDbContext = new Mock<MsSqlDbContext>();
        //    var mockedSaveChanges = new Mock<SaveContext>(validDbContext.Object);
           

            // Act
        //    userRepositoryMock.SetReturnsDefault(UserDbModel);
        //    var booksService = new BookService(bookRepositoryMock.Object, userRepositoryMock.Object, mockedSaveChanges.Object);
        //    booksService.AddBook("Title", "Author", "Description", (Decimal)2.30, "asdfghjkl", testGuid, userId.ToString());

            // Assert
        //   mockedSaveChanges.Verify(ser => ser.Commit(), Times.Once);
        //}

    }
}
