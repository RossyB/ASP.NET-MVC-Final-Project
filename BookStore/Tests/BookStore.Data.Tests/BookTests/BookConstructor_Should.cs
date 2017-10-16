using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.Collections.Generic;

namespace BookStore.Data.Tests.BookTests
{
    [TestFixture]
    public class BookConstructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            //Arange & Act
            var book = new Book();

            // Assert
            Assert.IsInstanceOf<Book>(book);
        }

        [Test]
        public void InitializeBookCollectionCorrectly()
        {
            // Arrange & Act
            var book = new Book();
            var comments = book.Comments;

            // Assert
            Assert.That(comments, Is.Not.Null.And.InstanceOf<HashSet<Comment>>());
        }
    }
}
