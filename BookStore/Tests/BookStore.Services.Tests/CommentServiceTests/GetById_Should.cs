using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using System.Collections.Generic;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class CommentGetById_Should
    {
        [Test]
        public void ReturnCategory_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var commentrepositoryMock = new Mock<IEfRepository<Comment>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();
            var commentId = Guid.NewGuid();

            commentrepositoryMock.Setup(m => m.GetById(commentId)).Returns(new Comment() { Id = commentId });

            CommentService commentService = new CommentService(commentrepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);
            

            // Act
            var comment = commentService.GetById(commentId);

            // Assert
            Assert.IsNotNull(comment);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            var commentRepositoryMock = new Mock<IEfRepository<Comment>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();
            Guid id = Guid.NewGuid();

            CommentService commentService = new CommentService(commentRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);
            commentRepositoryMock.Setup(m => m.GetById(id)).Returns((Comment)null);

            // Act
            Comment comment = commentService.GetById(id).FirstOrDefault();

            // Assert
            Assert.IsNull(comment);
        }
    }
}
