using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class LocationSearchFilterTests
    {
        [Test]
        public void TestCreateLocationNearSearch()
        {
            const string propertyName = "query";
            const string equalityValue = "42.14,54.22";
            var filter = new LocationSearchFilter(propertyName, 42.14m, 54.22m);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LocationNear.ToString(), filter.Comparison);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLocationNearThrowsExceptionOnInvalidPropertyName()
        {
            new LocationSearchFilter(null, 42.14m, 54.22m);
        }

        [Test]
        public void TestCreateLocationWithinSearch()
        {
            const string propertyName = "query";
            const string equalityValue = "42.14,54.22,43.14,56.22";
            var filter = new LocationSearchFilter(propertyName, 42.14m, 54.22m, 43.14m, 56.22m);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LocationWithin.ToString(), filter.Comparison);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLocationWithinThrowsExceptionOnInvalidPropertyName()
        {
            new LocationSearchFilter("", 42.14m, 54.22m, 43.14m, 56.22m);
        }

        [Test]
        public void TestCreateLocationRadiusSearch()
        {
            const string propertyName = "query";
            const string equalityValue = "42.14,54.22,43.14";
            var filter = new LocationSearchFilter(propertyName, 42.14m, 54.22m, 43.14m);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LocationWithin.ToString(), filter.Comparison);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLocationRadiusThrowsExceptionOnInvalidPropertyName()
        {
            new LocationSearchFilter("", 42.14m, 54.22m, 43.14m);
        }
    }
}
