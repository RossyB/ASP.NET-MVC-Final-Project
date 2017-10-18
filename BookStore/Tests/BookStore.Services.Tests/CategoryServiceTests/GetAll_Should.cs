using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using BookStore.Data.Repositories;
using BookStore.Data.Model;
using System.Collections.Generic;

namespace BookStore.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void BeCalled_WhenParamsAreValid()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Category>>();
            

            CategoryService categoryService = new CategoryService(repositoryMock.Object);

            // Act
            categoryService.GetAll();

            // Assert
            repositoryMock.Verify(rep => rep.All, Times.Once);
        }

        [Test]
        public void NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var repositoryMock = new Mock<IEfRepository<Category>>();

            // Assert
            repositoryMock.Verify(rep => rep.All, Times.Never);
        }

        [Test]
        public void ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Category>>();

            CategoryService categoryService = new CategoryService(repositoryMock.Object);

            // Act
            IEnumerable<Category> expectedCategoriesResult = new List<Category>();
            repositoryMock.Setup(rep => rep.All).Returns(() => expectedCategoriesResult.AsQueryable());

            // Assert
            Assert.AreEqual(categoryService.GetAll(), expectedCategoriesResult);
        }
    }
}
