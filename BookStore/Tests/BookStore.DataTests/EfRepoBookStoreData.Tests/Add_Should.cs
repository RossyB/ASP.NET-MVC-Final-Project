using System;
using System.Data.Entity;
using NUnit.Framework;
using Moq;
using BookStore.Data.Model;
using BookStore.Data.Repositories;

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

        //[Test]
        //public void CallOnce_DbSet_Add_WithSameArguments()
        //{
            // Arange
        //    var testGuid = Guid.NewGuid();
        //    var mockedDbModel = new Book() { OwnerId = testGuid.ToString()};

        //    var mockedDbSet = new Mock<DbSet<Book>>();
        //    mockedDbSet.Setup(x => x.Add(mockedDbModel)).Verifiable();

        //    var mockedDbContext = new Mock<MsSqlDbContext>();
        //    mockedDbContext.Setup(x => x.Set<Book>()).Returns(mockedDbSet.Object);

        //    var obj = new EfRepository<Book>(mockedDbContext.Object);

            // Act
        //    obj.Add(mockedDbModel);

            // Assert
            //mockedDbSet.Verify(x => x.Add(mockedDbModel), Times.Once);
        //}
    }
}
