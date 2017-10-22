using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookStore.Common;

namespace BookStore.Data.Models.Tests.BookTests
{
    [TestFixture]
    public class BookRating_Should
    {

        [Test]
        public void HaveCorrectRangeAttributeMinimum()
        {
            // Arrange
            var rathingProperty = typeof(Book).GetProperty("Rathing");

            // Act
            var rangeAttribute = rathingProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
                .Cast<System.ComponentModel.DataAnnotations.RangeAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(rangeAttribute.Minimum, Is.Not.Null.And.EqualTo(ValidationConstants.BookRatingMinValue));
        }

        [Test]
        public void HaveCorrectRangeAttributeMaximum()
        {
            // Arrange
            var rathingeProperty = typeof(Book).GetProperty("Rathing");

            // Act
            var rangeAttribute = rathingeProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
                .Cast<System.ComponentModel.DataAnnotations.RangeAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(rangeAttribute.Maximum, Is.Not.Null.And.EqualTo(ValidationConstants.BookRatingMaxValue));
        }

        [Test]

        public void HaveCorrectRangeAttributeType()
        {
            // Arrange
            var rathingProperty = typeof(Book).GetProperty("Rathing");

            // Act
            var rangeAttribute = rathingProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
                .Cast<System.ComponentModel.DataAnnotations.RangeAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(rangeAttribute.OperandType, Is.Not.Null);
            Assert.True(rangeAttribute.OperandType.ToString() == "System.Int32");
        }

        [Test]
        public void HaveCorrectRangeErrorMessage()
        {
            // 
            var ratingProperty = typeof(Book).GetProperty("Rathing");

            // Act
            var rangeAttribute = ratingProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
                .Cast<System.ComponentModel.DataAnnotations.RangeAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(rangeAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.RatingOutOfRangeErrorMessage));
        }

        [TestCase(3)]
        [TestCase(7)]
        public void GetAndSetDataCorrectly(int testRating)
        {
            // Arrange & Act
            var book = new Book() { Rathing = testRating };

            // Assert
            Assert.AreEqual(book.Rathing, testRating);
        }
    }
}
