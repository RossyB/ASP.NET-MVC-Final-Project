using System;
using NUnit.Framework;
using BookStore.Data;

namespace BookStore.Data.Tests.BookStoreDbContext.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new Data.MsSqlDbContext();

            // Assert
            Assert.IsInstanceOf<Data.MsSqlDbContext>(context);
        }

        [Test]
        public void Constructor_Should_Return_InstanceOfMsSqlDbContext()
        {
            // Arrange & Act
            var context = new Data.MsSqlDbContext();

            // Assert
            Assert.IsInstanceOf<IMsSqlDbContext>(context);
        }
    }
}
