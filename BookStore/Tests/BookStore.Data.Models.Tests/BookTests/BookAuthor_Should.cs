using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookStore.Common;

namespace BookStore.Data.Models.Tests.BookTests
{
    [TestFixture]
    public class BookAuthor_Should
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            // Arrange
            var authorProperty = typeof(Book).GetProperty("Author");

            // Act
            var requiredAttribute = authorProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void HaveCorrectMinLength()
        {
            // Arrange
            var authorProperty = typeof(Book).GetProperty("Author");

            // Act
            var minLengthAttribute = authorProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookAuthorMinLength));
        }

        [Test]
        public void HaveCorrectMinLengthErrorMessage()
        {
            // Arrange
            var authorProperty = typeof(Book).GetProperty("Author");

            // Act
            var minLengthAttribute = authorProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MinLengthFieldErrorMessage));
        }

        [Test]
        public void HaveCorrectMaxLength()
        {
            // Arrange
            var authorProperty = typeof(Book).GetProperty("Author");

            // Act
            var maxLengthAttribute = authorProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookAuthorMaxLength));
        }

        [Test]
        public void HaveCorrectMaxLengthErrorMessage()
        {
            // Arrange
            var authorProperty = typeof(Book).GetProperty("Author");

            // Act
            var maxLengthAttribute = authorProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MaxLengthFieldErrorMessage));
        }

        [TestCase("Randall Baker")]
        [TestCase("Terry Pratchett")]
        public void GetAndSetDataCorrectly(string testAuthor)
        {
            // Arrange & Act
            var book = new Book() { Author = testAuthor };

            // Assert
            Assert.AreEqual(book.Author, testAuthor);
        }

    }
}
