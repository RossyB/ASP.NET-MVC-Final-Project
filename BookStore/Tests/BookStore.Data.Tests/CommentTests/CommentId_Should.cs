using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookStore.Data.Models.Tests.CategoryTests
{
    public class CommentId_Should
    {
        [Test]
        public void HaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Comment).GetProperty("Id");

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
            var commnet= new Comment() { Id = testId };

            // Assert
            Assert.AreEqual(testId, commnet.Id);
        }
    }
}
