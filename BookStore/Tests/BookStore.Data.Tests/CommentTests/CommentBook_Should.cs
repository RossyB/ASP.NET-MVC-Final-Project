using System;
using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Tests.BookTests
{
    [TestFixture]
    public class CommentBook_Should
    {
        [Test]
        public void BookId__GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid();
            var comment = new Comment { BookId = testId };

            // Assert
            Assert.AreEqual(comment.BookId, testId);
        }

        [TestCase("The Book title")]
        public void Book_Should_GetAndSetDataCorrectly(string testBookTitle)
        {
            // Arrange & Act         
            var book = new Book() { Title = testBookTitle };
            var comment = new Comment { Book = book };

            // Assert
            Assert.AreEqual(comment.Book.Title, testBookTitle);
        }
    }
}
