using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search
{
    [TestClass]
    public class EqualitySearchFilterTests
    {
        [TestMethod]
        public void TestCreatesEqualsFilterByDefault()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new EqualitySearchFilter(propertyName, equalityValue);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.Equal.ToString(), filter.Comparison);
        }

        [TestMethod]
        public void TestCreatesNotEqualFilter()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new EqualitySearchFilter(propertyName, equalityValue, Equality.NotEqual);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.NotEqual.ToString(), filter.Comparison);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidPropertyName()
        {
            const string equalityValue = "asd";
            new EqualitySearchFilter(null, equalityValue);
        }
    }
}
