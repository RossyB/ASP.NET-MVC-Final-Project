using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using BookStore.Common;
using System.Linq;

namespace BookStore.Data.Models.Tests.BookTests
{
    [TestFixture]
    public class BookDescription_Should
    {
        [Test]
        public void HaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Book).GetProperty("Description");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookDescriptionMinLength));
        }

        [Test]
        public void HaveCorrectMinLengthErrorMessage()
        {
            // Arrange
            var nameProperty = typeof(Book).GetProperty("Description");

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
            var nameProperty = typeof(Book).GetProperty("Description");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookDescriptionMaxLength));
        }

        [Test]
        public void HaveCorrectMaxLengthErrorMessage()
        {
            // Arrange
            var nameProperty = typeof(Book).GetProperty("Description");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MaxLengthFieldErrorMessage));
        }

        [TestCase("This is the book description.")]
        public void GetAndSetDataCorrectly(string testDescription)
        {
            // Arrange & Act
            var book = new Book() { Description = testDescription };

            // Assert
            Assert.AreEqual(book.Description, testDescription);
        }
    }
}
