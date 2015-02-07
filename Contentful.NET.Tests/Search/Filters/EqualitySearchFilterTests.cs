using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class EqualitySearchFilterTests
    {
        [Test]
        public void TestCreatesEqualsFilterByDefault()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new EqualitySearchFilter(propertyName, equalityValue);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.Equal.ToString(), filter.Comparison);
        }

        [Test]
        public void TestCreatesNotEqualFilter()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new EqualitySearchFilter(propertyName, equalityValue, Equality.NotEqual);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.NotEqual.ToString(), filter.Comparison);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidPropertyName()
        {
            const string equalityValue = "asd";
            new EqualitySearchFilter(null, equalityValue);
        }
    }
}
