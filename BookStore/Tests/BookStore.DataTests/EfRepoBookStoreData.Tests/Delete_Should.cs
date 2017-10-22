using System;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using BookStore.Data.Model;
using BookStore.Data.Repositories;

namespace BookStore.Data.Tests.EfRepoBookStoreData.Tests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedSet = new Mock<DbSet<Book>>();

            // Act
            mockedDbContext.Setup(set => set.Set<Book>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfRepository<Book>(mockedDbContext.Object);
            Book entity = null;

            // Assert
            Assert.That(() => mockedDbSet.Delete(entity),
                Throws.InstanceOf<NullReferenceException>());
        }
    }
}
