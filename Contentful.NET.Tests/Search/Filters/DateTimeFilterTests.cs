using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class DateTimeFilterTests
    {
        private const string ExpectedDate = "2012-02-01T00:30:21Z";
        private readonly DateTime _date = new DateTime(2012, 02, 01, 00, 30, 21, DateTimeKind.Utc);

        [Test]
        public void TestCreateLessThan()
        {
            AssertEquality(NumericEquality.LessThan, SearchFilterComparer.LessThan);
        }

        [Test]
        public void TestCreateLessThanEqual()
        {
            AssertEquality(NumericEquality.LessThanEqualTo, SearchFilterComparer.LessThanEqual);
        }

        [Test]
        public void TestCreateGreaterThan()
        {
            AssertEquality(NumericEquality.GreaterThan, SearchFilterComparer.GreaterThan);
        }

        [Test]
        public void TestCreateGreaterThanEqual()
        {
            AssertEquality(NumericEquality.GreaterThanEqualTo, SearchFilterComparer.GreaterThanEqual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionForInvalidProperty()
        {
            new DateTimeSearchFilter(null, _date, NumericEquality.LessThan);
        }

        private void AssertEquality(NumericEquality equality, SearchFilterComparer comparer)
        {
            const string propertyName = "prop";
            var filter = new DateTimeSearchFilter(propertyName, _date, equality);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(ExpectedDate, filter.Value);
            Assert.AreEqual(comparer.ToString(), filter.Comparison);
        }
    }
}
