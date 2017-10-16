using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookStore.Data.Tests.CategoryTests
{
    public class CategoryId_Should
    {
        [Test]
        public void HaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Category).GetProperty("Id");

            // Act
            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(keyAttribute, Is.Not.Null);
        }

        [Test]
        public void GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid();
            var category = new Category() { Id = testId };

            // Assert
            Assert.AreEqual(testId, category.Id);
        }
    }
}
