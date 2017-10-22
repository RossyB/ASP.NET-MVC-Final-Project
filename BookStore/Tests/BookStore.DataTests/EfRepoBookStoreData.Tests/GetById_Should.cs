using System;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using BookStore.Data.Model;
using BookStore.Data.Repositories;

namespace BookStore.Data.Tests.EfRepoBookStoreData.Tests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrectResult_WhenParameterIsValid()
        {
            // Arrange 
            var mockedSet = new Mock<DbSet<Book>>();
            var mockedDbContext = new Mock<MsSqlDbContext>();
            var fakeAdvert = new Mock<Book>();
            var validId = Guid.NewGuid();

            // Act
            mockedDbContext.Setup(mock => mock.Set<Book>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfRepository<Book>(mockedDbContext.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<Guid>())).Returns(fakeAdvert.Object);

            // Assert
            Assert.That(mockedDbSet.GetById(validId), Is.Not.Null);
            Assert.AreEqual(mockedDbSet.GetById(validId), fakeAdvert.Object);
        }
    }
}
