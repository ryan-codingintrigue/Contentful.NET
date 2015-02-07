using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class NumericSearchFilterTests
    {
        [Test]
        public void TestCreateLessThan()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.LessThan);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LessThan.ToString(), filter.Comparison);
        }

        [Test]
        public void TestCreateLessThanEqual()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.LessThanEqualTo);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LessThanEqual.ToString(), filter.Comparison);
        }

        [Test]
        public void TestCreateGreaterThan()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.GreaterThan);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.GreaterThan.ToString(), filter.Comparison);
        }

        [Test]
        public void TestCreateGreaterThanEqual()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.GreaterThanEqualTo);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.GreaterThanEqual.ToString(), filter.Comparison);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidPropertyName()
        {
            new NumericSearchFilter(null, 15, NumericEquality.GreaterThanEqualTo);
        }
    }
}
