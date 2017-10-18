using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using BookStore.Data.Repositories.SaveContext;

namespace BookStore.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterAreNotNull()
        {
            // Arrange 
            var commentRepositoryMock = new Mock<IEfRepository<Comment>>();
            var userRepositoryMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            CommentService commentService = new CommentService(commentRepositoryMock.Object, userRepositoryMock.Object, contextMock.Object);

            // Assert
            Assert.That(commentService, Is.InstanceOf<CommentService>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenCommentRepositoryIsNull()
        {
            // Arrange


            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new CommentService(null, null, null));

        }
    }
}