using System;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using BookStore.Data.Model;
using BookStore.Data.Repositories;

namespace BookStore.Data.Tests.EfRepoBookStoreData.Tests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnEntitiesOfGivenSet()
        {
            // Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedSet = new Mock<DbSet<Book>>();

            // Act
            mockedDbContext.Setup(x => x.Set<Book>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfRepository<Book>(mockedDbContext.Object);

            // Assert
            //Assert.NotNull(mockedDbSet.All());
            //Assert.IsInstanceOf(typeof(DbSet<Book>), mockedDbSet.All());
            //Assert.AreSame(mockedDbSet.All(), mockedDbSet.DbSet);
        }
    }
}
