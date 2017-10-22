using NUnit.Framework;
using BookStore.Data.Model;

namespace BookStore.Data.Tests.CategoryTests
{
    public class CommentConstructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            //Arange & Act
            var comment = new Comment();

            // Assert
            Assert.IsInstanceOf<Comment>(comment);
        }
    }
}
