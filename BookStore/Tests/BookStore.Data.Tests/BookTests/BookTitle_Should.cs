using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookStore.Common;

namespace BookStore.Data.Tests.BookTests
{
    [TestFixture]
    public class BookTitle_Should
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            // Arrange
            var titleProperty = typeof(Book).GetProperty("Title");

            // Act
            var requiredAttribute = titleProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void HaveCorrectMinLength()
        {
            // Arrange
            var titleProperty = typeof(Book).GetProperty("Title");

            // Act
            var minLengthAttribute = titleProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookTitleMinLength));
        }

        [Test]
        public void HaveCorrectMinLengthErrorMessage()
        {
            // Arrange
            var titleProperty = typeof(Book).GetProperty("Title");

            // Act
            var minLengthAttribute = titleProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MinLengthFieldErrorMessage));
        }

        [Test]
        public void HaveCorrectMaxLength()
        {
            // Arrange
            var titleProperty = typeof(Book).GetProperty("Title");

            // Act
            var maxLengthAttribute = titleProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookTitleMaxLength));
        }

        [Test]
        public void HaveCorrectMaxLengthErrorMessage()
        {
            // Arrange
            var titleProperty = typeof(Book).GetProperty("Title");

            // Act
            var maxLengthAttribute = titleProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MaxLengthFieldErrorMessage));
        }

        [TestCase("Ender's Game")]
        [TestCase("Fantastic Beasts the original screenplay")]
        public void GetAndSetDataCorrectly(string testTitle)
        {
            // Arrange & Act
            var book = new Book() { Title = testTitle };

            // Assert
            Assert.AreEqual(book.Title, testTitle);
        }

    }
}
