using System;
using NUnit.Framework;
using BookStore.Data.Repositories.SaveContext;
using Moq;

namespace BookStore.Data.Tests.ContextSaveChanges.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Contructor_Should_ThrowArgumentNullException_IfPassedDbContextIsNull()
        {
            // Arrange
            MsSqlDbContext dbContextThatIsNull = null;

            // Act & Assert
            Assert.That(
                () => new SaveContext(dbContextThatIsNull),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("MsSqlDbContext"));
        }

        [Test]
        public void NotThrowArgumentNullException_IfPassedDbContextIsNotNull()
        {
            // Arrange
            var validDbContext = new Mock<MsSqlDbContext>();
            var carSystemDbContextSaveChanges = new SaveContext(validDbContext.Object);

            // Act & Assert
            Assert.That(carSystemDbContextSaveChanges, Is.Not.Null);
        }
    }
}
