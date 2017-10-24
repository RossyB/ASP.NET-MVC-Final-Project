using System;
using NUnit.Framework;
using BookStore.Services;
using Moq;
using BookStore.Web.Controllers;

namespace BookStore.Controllers.Tests.CommentController.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenBooksServiceIsNull()
        {
            var bookServiceMock = new Mock<IBookService>();
            var commentServiceMock = new Mock<ICommentService>();

            Assert.That(() => new CommentsController(commentServiceMock.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("bookService"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenCommentsServiceIsNull()
        {
            var bookServiceMock = new Mock<IBookService>();
            var commentServiceMock = new Mock<ICommentService>();

            Assert.That(() => new CommentsController(null, bookServiceMock.Object),
                            Throws.ArgumentNullException.With.Message.Contains("commentService"));
        }

        [Test]
        public void CreateInstanceOfCommentsControllerWhenParametersAreNotNull()
        {
            var bookServiceMock = new Mock<IBookService>();
            var commentServiceMock = new Mock<ICommentService>();

            var commentsController = new CommentsController(commentServiceMock.Object, bookServiceMock.Object);

            Assert.IsInstanceOf<CommentsController>(commentsController);
        }
    }
}
