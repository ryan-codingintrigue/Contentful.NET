using System;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class OrderBySearchFilterTests
    {
        [Test]
        public void TestCanCreateAscending()
        {
            const string propertyName = "test";
            var orderBy = new OrderBySearchFilter(propertyName, OrderByDirection.Ascending);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("order", orderBy.Field);
            Assert.AreEqual(propertyName, orderBy.Value);
        }

        [Test]
        public void TestCanCreateDescending()
        {
            const string propertyName = "test";
            var orderBy = new OrderBySearchFilter(propertyName, OrderByDirection.Ascending);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("order", orderBy.Field);
            Assert.AreEqual(propertyName, orderBy.Value);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidProperty()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new OrderBySearchFilter(null, OrderByDirection.Ascending);
        }
    }
}
