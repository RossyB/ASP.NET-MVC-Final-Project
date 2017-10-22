using NUnit.Framework;
using BookStore.Data;

namespace BookStore.Data.Tests.BookStoreDbContext.Tests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Create_Should_ReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = MsSqlDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<IMsSqlDbContext>(newContext);
        }
    }
}
