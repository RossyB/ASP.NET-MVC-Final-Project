using System;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;

namespace BookStore.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterAreNotNull()
        {
            // Arrange 
            var repositoryMock = new Mock<IEfRepository<Category>>();

            // Act
            CategoryService categoryService = new CategoryService(repositoryMock.Object);

            // Assert
            Assert.That(categoryService, Is.InstanceOf<CategoryService>());
        }
    }
}
