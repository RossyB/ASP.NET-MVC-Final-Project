using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.Collections.Generic;

namespace BookStore.Data.Tests.CategoryTests
{
    public class CategoryConstructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            //Arange & Act
            var category = new Category();

            // Assert
            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void InitializeProductCollectionCorrectly()
        {
            // Arrange & Act
            var category = new Category();
            var products = category.Books;

            // Assert
            Assert.That(products, Is.Not.Null.And.InstanceOf<HashSet<Book>>());
        }
    }
}
