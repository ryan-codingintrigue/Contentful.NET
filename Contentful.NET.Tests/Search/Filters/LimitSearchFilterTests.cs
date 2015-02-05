using System;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestClass]
    public class LimitSearchFilterTests
    {
        [TestMethod]
        public void TestCanCreate()
        {
            var orderBy = new LimitSearchFilter(10);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("limit", orderBy.Field);
            Assert.AreEqual("10", orderBy.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidLimit()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new LimitSearchFilter(-10);
        }
    }
}
