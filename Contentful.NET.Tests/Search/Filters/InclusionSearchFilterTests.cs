using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class InclusionSearchFilterTests
    {
        [Test]
        public void TestCreatesInFilterByDefault()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new InclusionSearchFilter(propertyName, equalityValue);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.In.ToString(), filter.Comparison);
        }

        [Test]
        public void TestCreatesNotInFilter()
        {
            const string propertyName = "prop";
            const string equalityValue = "asd";
            var filter = new InclusionSearchFilter(propertyName, equalityValue, InEquality.NotIn);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.NotIn.ToString(), filter.Comparison);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidPropertyName()
        {
            const string equalityValue = "asd";
            new InclusionSearchFilter("", equalityValue, InEquality.NotIn);
        }
    }
}
