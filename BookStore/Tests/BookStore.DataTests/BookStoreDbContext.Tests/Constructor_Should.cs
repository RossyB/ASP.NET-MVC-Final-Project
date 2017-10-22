using NUnit.Framework;
using BookStore.Data;

namespace BookStore.DataTests.BookStoreDbContext.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new MsSqlDbContext();

            // Assert
            Assert.IsInstanceOf<MsSqlDbContext>(context);
        }

        [Test]
        public void Constructor_Should_Return_InstanceOfMsSqlDbContext()
        {
            // Arrange & Act
            var context = new MsSqlDbContext();

            // Assert
            Assert.IsInstanceOf<IMsSqlDbContext>(context);
        }
    }
}
