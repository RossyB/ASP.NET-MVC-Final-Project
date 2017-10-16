using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NUnit.Framework;
using BookStore.Data.Model;
using BookStore.Common;

namespace BookStore.Data.Tests.CategoryTests
{
    public class CommentContent_Should
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            // Arrange
            var contentProperty = typeof(Comment).GetProperty("Content");

            // Act
            var requiredAttribute = contentProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void HaveCorrectMinLength()
        {
            // Arrange
            var contentProperty = typeof(Comment).GetProperty("Content");

            // Act
            var minLengthAttribute = contentProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CommentContentMinLength));
        }

        [Test]
        public void HaveCorrectMinLengthErrorMessage()
        {
            // Arrange
            var contentProperty = typeof(Comment).GetProperty("Content");

            // Act
            var minLengthAttribute = contentProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MinLengthFieldErrorMessage));
        }

        [Test]
        public void HaveCorrectMaxLength()
        {
            // Arrange
            var contentProperty = typeof(Comment).GetProperty("Content");

            // Act
            var maxLengthAttribute = contentProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CommentContentMaxLength));
        }

        [Test]
        public void HaveCorrectMaxLengthErrorMessage()
        {
            // Arrange
            var contentProperty = typeof(Comment).GetProperty("Content");

            // Act
            var maxLengthAttribute = contentProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.ErrorMessage, Is.Not.Null.And.EqualTo(ValidationConstants.MaxLengthFieldErrorMessage));
        }

        [TestCase("This is very good book.")]
        public void GetAndSetDataCorrectly(string testContent)
        {
            // Arrange & Act
            var comment = new Comment() { Content = testContent };

            // Assert
            Assert.AreEqual(comment.Content, testContent);
        }
    }
}
