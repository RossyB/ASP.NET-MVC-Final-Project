using System;
using NUnit.Framework;
using BookStore.Data.Model;
using System.Collections.Generic;

namespace BookStore.Data.Models.Tests.CategoryTests
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
        public void InitializeCategoryCollectionCorrectly()
        {
            // Arrange & Act
            var category = new Category();
            var books = category.Books;

            // Assert
            Assert.That(books, Is.Not.Null.And.InstanceOf<HashSet<Book>>());
        }
    }
}
