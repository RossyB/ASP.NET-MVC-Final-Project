using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Data.Tests.ContextSaveChanges.Tests
{
    [TestFixture]
    public class Commit_Should
    {
        [Test]
        public void SaveChanges_Should_CallSaveChangesOnce()
        {
            // Arrange
            var validDbContext = new Mock<MsSqlDbContext>();
            var carSystemDbContextSaveChanges = new SaveContext(validDbContext.Object);

            // Act
            carSystemDbContextSaveChanges.Commit();

            // Assert
            validDbContext.Verify(u => u.SaveChanges(), Times.Once);
        }
    }
}
