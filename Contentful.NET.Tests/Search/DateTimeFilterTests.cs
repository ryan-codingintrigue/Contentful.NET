using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search
{
    [TestClass]
    public class DateTimeFilterTests
    {
        private const string ExpectedDate = "2012-02-01T00:30:21Z";
        private readonly DateTime _date = new DateTime(2012, 02, 01, 00, 30, 21, DateTimeKind.Utc);

        [TestMethod]
        public void TestCreateLessThan()
        {
            AssertEquality(NumericEquality.LessThan, SearchFilterComparer.LessThan);
        }

        [TestMethod]
        public void TestCreateLessThanEqual()
        {
            AssertEquality(NumericEquality.LessThanEqualTo, SearchFilterComparer.LessThanEqual);
        }

        [TestMethod]
        public void TestCreateGreaterThan()
        {
            AssertEquality(NumericEquality.GreaterThan, SearchFilterComparer.GreaterThan);
        }

        [TestMethod]
        public void TestCreateGreaterThanEqual()
        {
            AssertEquality(NumericEquality.GreaterThanEqualTo, SearchFilterComparer.GreaterThanEqual);
        }

        [TestMethod]
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
