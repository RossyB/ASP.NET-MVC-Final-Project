using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookStore.Common;

namespace BookStore.Data.Tests.BookTests
{
    [TestFixture]
    public class BookImageUrl_Should
    {
        [Test]
        public void HaveCorrectMinLength()
        {
            // Arrange
            var imageUrlProperty = typeof(Book).GetProperty("BookImageUrl");

            // Act
            var minLengthAttribute = imageUrlProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookImageUrlMinLength));
        }

        [Test]
        public void HaveCorrectMinLengthErrorMessage()
        {
            // Arrange
            var imageUrlProperty = typeof(Book).GetProperty("BookImageUrl");

            // Act
            var minLengthAttribute = imageUrlProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MinLengthFieldErrorMessage));
        }

        [Test]
        public void HaveCorrectMaxLength()
        {
            // Arrange
            var imageUrlProperty = typeof(Book).GetProperty("BookImageUrl");

            // Act
            var maxLengthAttribute = imageUrlProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.BookImageUrlMaxLength));
        }

        [Test]
        public void HaveCorrectMaxLengthErrorMessage()
        {
            // Arrange
            var imageUrlProperty = typeof(Book).GetProperty("BookImageUrl");

            // Act
            var maxLengthAttribute = imageUrlProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MaxLengthFieldErrorMessage));
        }

        [TestCase("http://www.bookstore.com/Picture5.png")]
        [TestCase("http://www.elephantbookstore.com/image/cache/catalog/Nikola%2004.04.2017/Picture7-425x425.png")]
        public void GetAndSetDataCorrectly(string testBookImageUrl)
        {
            // Arrange & Act
            var book = new Book() { BookImageUrl = testBookImageUrl };

            // Assert
            Assert.AreEqual(book.BookImageUrl, testBookImageUrl);
        }

    }
}
