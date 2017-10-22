using System;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using BookStore.Data.Model;
using BookStore.Data.Repositories;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;

namespace BookStore.Data.Tests.EfRepoBookStoreData.Tests
{
    [TestFixture]
    public class Add_Should
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
            Assert.That(() => mockedDbSet.Add(entity),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
