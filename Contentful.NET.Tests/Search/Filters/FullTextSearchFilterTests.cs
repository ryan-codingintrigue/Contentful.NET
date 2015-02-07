using Contentful.NET.Search;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class FullTextSearchFilterTests
    {
        [Test]
        public void TestCreateAllFieldFilter()
        {
            const string propertyName = "query";
            const string equalityValue = "asd";
            var filter = new FullTextSearchFilter(equalityValue);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.Equal.ToString(), filter.Comparison);
        }

        [Test]
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
