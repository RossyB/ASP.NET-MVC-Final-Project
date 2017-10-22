using System;
using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Tests.BookTests
{
    [TestFixture]
    public class CommentUser_Should
    {
        [Test]
        public void UserId__GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var testId = Guid.NewGuid().ToString();
            var comment = new Comment { UserId = testId };

            // Assert
            Assert.AreEqual(comment.UserId, testId);
        }

        [TestCase("Petarcho")]
        public void User_Should_GetAndSetDataCorrectly(string testUserNameTitle)
        {
            // Arrange & Act         
            var user = new User() { UserName = testUserNameTitle };
            var comment = new Comment { User = user };

            // Assert
            Assert.AreEqual(comment.User.UserName, testUserNameTitle);
        }
    }
}
