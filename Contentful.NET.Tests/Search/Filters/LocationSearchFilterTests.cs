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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationNearThrowsExceptionOnInvalidLatitude()
        {
            new LocationSearchFilter("property", -180, 90);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationNearThrowsExceptionOnInvalidLongitude()
        {
            new LocationSearchFilter("property", 45, 200);
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationRadiusThrowsExceptionOnInvalidLatitude()
        {
            new LocationSearchFilter("property", -180, 90, 45);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationRadiusThrowsExceptionOnInvalidLongitude()
        {
            new LocationSearchFilter("property", 45, 200, 45);
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

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationWithinThrowsExceptionOnInvalidFirstLatitude()
        {
            new LocationSearchFilter("property", -180, 90, 45, 45);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationWithinThrowsExceptionOnInvalidFirstLongitude()
        {
            new LocationSearchFilter("property", 45, 200, 45, 45);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationWithinThrowsExceptionOnInvalidSecondLatitude()
        {
            new LocationSearchFilter("property", 45, 45, -180, 90);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLocationWithinThrowsExceptionOnInvalidSecondLongitude()
        {
            new LocationSearchFilter("property", 45, 45, 45, 200);
        }
    }
}
