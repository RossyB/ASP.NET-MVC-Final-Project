using NUnit.Framework;
using Moq;
using BookStore.Services;
using BookStore.Web.Controllers;

namespace BookStore.Controllers.Tests.HomesController.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessageWhenBooksServiceIsNull()
        {
            var bookServiceMock = new Mock<IBookService>();

            Assert.That(() => new HomeController(null),
                            Throws.ArgumentNullException.With.Message.Contains("bookService"));
        }

        [Test]
        public void CreateInstanceOfHomeControllerWhenParametersAreNotNull()
        {
            var bookServiceMock = new Mock<IBookService>();

            var homeController = new HomeController(bookServiceMock.Object);

            Assert.IsInstanceOf<HomeController>(homeController);
        }
    }
}
