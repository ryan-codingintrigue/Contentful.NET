using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search
{
    [TestClass]
    public class FullTextSearchFilterTests
    {
        [TestMethod]
        public void TestCreateAllFieldFilter()
        {
            const string propertyName = "query";
            const string equalityValue = "asd";
            var filter = new FullTextSearchFilter(equalityValue);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.Equal.ToString(), filter.Comparison);
        }

        [TestMethod]
        public void TestCreateSpecificFieldFilter()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new FullTextSearchFilter(equalityValue, propertyName);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.FullText.ToString(), filter.Comparison);
        }
    }
}
