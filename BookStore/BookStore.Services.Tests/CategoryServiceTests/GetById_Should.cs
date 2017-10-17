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
    public class GetById_Should
    {
        [Test]
        public void ReturnCategory_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Category>>();
            var categoryId = Guid.NewGuid();
            
            repositoryMock.Setup(m => m.GetById(categoryId)).Returns(new Category() { Id = categoryId});

            CategoryService categoryService = new CategoryService(repositoryMock.Object);
            

            // Act
            var category = categoryService.GetById(categoryId);

            // Assert
            Assert.IsNotNull(category);
        }

        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            var repositoryMock = new Mock<IEfRepository<Category>>();

            CategoryService categoryService = new CategoryService(repositoryMock.Object);

            // Act
            Category category = categoryService.GetById(null).FirstOrDefault();

            // Assert
            Assert.IsNull(category);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Category>>();
            Guid id = Guid.NewGuid();

            CategoryService categoryService = new CategoryService(repositoryMock.Object);
            repositoryMock.Setup(m => m.GetById(id)).Returns((Category)null);

            // Act
            Category category = categoryService.GetById(id).FirstOrDefault();

            // Assert
            Assert.IsNull(category);
        }
    }
}
