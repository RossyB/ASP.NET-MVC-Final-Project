using System;
using System.Data.Entity;
using NUnit.Framework;
using Moq;
using BookStore.Data.Model;
using BookStore.Data.Repositories;

namespace BookStore.Data.Tests.EfRepoBookStoreData.Tests
{
    [TestFixture]
    public class Update_Should
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
            Assert.That(() => mockedDbSet.Update(entity),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
