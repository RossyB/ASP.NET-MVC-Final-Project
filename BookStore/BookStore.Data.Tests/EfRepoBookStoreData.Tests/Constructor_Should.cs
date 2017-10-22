using System;
using NUnit.Framework;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using Moq;
using System.Data.Entity;

namespace BookStore.Data.Tests.EfRepoBookStoreData.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_IfDbContextPassedIsNull()
        {
            // Arrange
            MsSqlDbContext nullContext = null;

            // Act & Assert
            Assert.That(() => new EfRepository<Book>(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(IMsSqlDbContext)));
        }

        [Test]
        public void WorkCorrectly_IfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedModel = new Mock<DbSet<Book>>();

            // Act
            mockedDbContext.Setup(x => x.Set<Book>()).Returns(mockedModel.Object);
            var mockedDbSet = new EfRepository<Book>(mockedDbContext.Object);

            // Assert
            Assert.That(mockedDbSet, Is.Not.Null);
        }

        [Test]
        public void SetContextCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedModel = new Mock<DbSet<Book>>();

            // Act
            mockedContext.Setup(x => x.Set<Book>()).Returns(mockedModel.Object);
            var mockedDbSet = new EfRepository<Book>(mockedContext.Object);

            // Assert
            Assert.That(mockedDbSet.Context, Is.Not.Null);
            Assert.That(mockedDbSet.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void SetDbSetCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedModel = new Mock<DbSet<Book>>();

            // Act
            mockedContext.Setup(x => x.Set<Book>()).Returns(mockedModel.Object);
            var repository = new EfRepository<Book>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
