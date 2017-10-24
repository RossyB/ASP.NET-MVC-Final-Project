using NUnit.Framework;
using Moq;
using BookStore.Services;
using BookStore.Web.Controllers;
using AutoMapper;

namespace BookStore.Controllers.Tests.BookController.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenBooksServiceIsNull()
        {
            var categoryServiceMock = new Mock<ICategoryService>();
            var commentServiceMock = new Mock<ICommentService>();

            Assert.That(() => new BooksController(null, categoryServiceMock.Object, commentServiceMock.Object),
                            Throws.ArgumentNullException.With.Message.Contains("bookService"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenCategoryServiceIsNull()
        {
            var bookServiceMock = new Mock<IBookService>();
            var commentServiceMock = new Mock<ICommentService>();

            Assert.That(() => new BooksController(bookServiceMock.Object, null, commentServiceMock.Object),
                            Throws.ArgumentNullException.With.Message.Contains("categoryService"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenCommentServiceIsNull()
        {
            var bookServiceMock = new Mock<IBookService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            Assert.That(() => new BooksController(bookServiceMock.Object, categoryServiceMock.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("commentService"));
        }

        [Test]
        public void CreateInstanceOfBooksControllerWhenParametersAreNotNull()
        {
            var bookServiceMock = new Mock<IBookService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var commentServiceMock = new Mock<ICommentService>();

            var booksController = new BooksController(bookServiceMock.Object, categoryServiceMock.Object, commentServiceMock.Object);

            Assert.IsInstanceOf<BooksController>(booksController);
        }
    }

}
