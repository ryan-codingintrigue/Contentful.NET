using System;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestClass]
    public class OrderBySearchFilterTests
    {
        [TestMethod]
        public void TestCanCreateAscending()
        {
            const string propertyName = "test";
            var orderBy = new OrderBySearchFilter(propertyName, OrderByDirection.Ascending);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("order", orderBy.Field);
            Assert.AreEqual(propertyName, orderBy.Value);
        }

        [TestMethod]
        public void TestCanCreateDescending()
        {
            const string propertyName = "test";
            var orderBy = new OrderBySearchFilter(propertyName, OrderByDirection.Ascending);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("order", orderBy.Field);
            Assert.AreEqual(propertyName, orderBy.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidProperty()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new OrderBySearchFilter(null, OrderByDirection.Ascending);
        }
    }
}
