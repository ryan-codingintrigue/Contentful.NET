using System;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestClass]
    public class SkipSearchFilterTests
    {
        [TestMethod]
        public void TestCanCreate()
        {
            var orderBy = new SkipSearchFilter(10);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("skip", orderBy.Field);
            Assert.AreEqual("10", orderBy.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidLimit()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new SkipSearchFilter(-10);
        }
    }
}
