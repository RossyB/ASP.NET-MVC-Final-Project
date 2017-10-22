using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using System.Collections.Generic;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void BeCalled_WhenParamsAreValid()
        {
            // Arrange
            var commentRepositoryMock = new Mock<IEfRepository<Comment>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            CommentService commentService = new CommentService(commentRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Act
            commentService.GetAll();

            // Assert
            commentRepositoryMock.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var commentRepositoryMock = new Mock<IEfRepository<Category>>();

            // Assert
            commentRepositoryMock.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var commentRepositoryMock = new Mock<IEfRepository<Comment>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            CommentService commentService = new CommentService(commentRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Act
            IEnumerable<Comment> expectedCategoriesResult = new List<Comment>();
            commentRepositoryMock.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            // Assert
            Assert.AreEqual(commentService.GetAll(), expectedCategoriesResult);
        }
    }
}
