using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NUnit.Framework;
using BookStore.Data.Model;
using BookStore.Common;

namespace BookStore.Data.Tests.CategoryTests
{
    public class CategoryName_Should
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void HaveUniqueAttribute()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute, Is.Not.Null);
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void HaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CategoryMinLength));
        }

        [Test]
        public void HaveCorrectMinLengthErrorMessage()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MinLengthFieldErrorMessage));
        }

        [Test]
        public void HaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CategoryMaxLength));
        }

        [Test]
        public void HaveCorrectMaxLengthErrorMessage()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MaxLengthFieldErrorMessage));
        }

        [TestCase("Fantasy")]
        [TestCase("Biography")]
        public void GetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var category = new Category() { Name = testName };

            // Assert
            Assert.AreEqual(category.Name, testName);
        }
    }
}
