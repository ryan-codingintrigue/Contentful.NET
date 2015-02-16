using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Contentful.NET.Exceptions;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Moq;
using NUnit.Framework;

namespace Contentful.NET.Tests
{
    [TestFixture]
    public class ContentfulClientTests
    {
        [Test]
        public void TestPublicConstructorCreatesHttpClient()
        {
            var client = new ContentfulClient("accessToken", "space");
            Assert.IsNotNull(client.HttpClient);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPublicConstructorThrowsArgumentExceptionWhenAccessTokenIsMissing()
        {
            new ContentfulClient("", "space");
        }

        [Test]
        [ExpectedException(typeof(ContentfulException))]
        public async Task TestMakeGetRequestThrowsContentfulExceptionOnErrorCode()
        {
            const string requestUri = "http://test.com";
            var cancellationToken = new CancellationToken();

            var mockHttpClient = new Mock<IHttpClientWrapper>();
            mockHttpClient.Setup(h => h.GetAsync(requestUri, cancellationToken))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

            var client = new ContentfulClient(mockHttpClient.Object);
            var result = await client.MakeGetRequestAsync(requestUri, cancellationToken);
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestAreAllNullReturnsTrueForAllNullArray()
        {
            var result = ContentfulClient.AreAllNull(null, null, null);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestAreAllNullReturnsFalseForSingleObject()
        {
            var result = ContentfulClient.AreAllNull(null, "one", null, null);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestAreAllNullReturnsFalseForAllObjects()
        {
            var result = ContentfulClient.AreAllNull("one", 1, DateTime.Now);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestQueryStringReturnsNullForNullFilters()
        {
            var result = ContentfulClient.GetQueryStringFromSearchFilters(null);
            Assert.IsNull(result);
        }

        [Test]
        public void TestQueryStringReturnsForValidFilters()
        {
            var filters = new ISearchFilter[]
            {
                new SkipSearchFilter(0),
                new LimitSearchFilter(15),
                new EqualitySearchFilter("test", "true"),
            };
            var result = ContentfulClient.GetQueryStringFromSearchFilters(filters);
            const string expectedQueryString = "skip=0&limit=15&test=true";
            Assert.AreEqual(expectedQueryString, result);
        }

        [Test]
        public void TestBuildsHttpClientWithAuthHeader()
        {
            const string accessToken = "accessToken1";
            var result = ContentfulClient.BuildHttpClient(accessToken);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task TestCanDeserializeFromHttpResponseMessage()
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ StringValue: \"value\", BoolValue: true }")
            };
            var result = await ContentfulClient.GetItemAsync<MockJsonModel>(message);
            Assert.IsNotNull(result);
            Assert.AreEqual("value", result.StringValue);
            Assert.IsTrue(result.BoolValue);
        }

        private const string RequestBaseUrl = "http://test.com/";
        [Test]
        public void GetRequestUrlReturnsBaseUrlIfAllPropertiesAreNull()
        {
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl);
            Assert.AreEqual(RequestBaseUrl, result);
        }

        [Test]
        public void GetRequestUrlReturnsIdOnly()
        {
            const string id = "12345";
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl, id);
            Assert.AreEqual("http://test.com/12345", result);
        }

        [Test]
        public void GetRequestUrlReturnsFiltersOnly()
        {
            var filters = new ISearchFilter[]
            {
                new EqualitySearchFilter("title", "hello"), 
                new EqualitySearchFilter("name", "test") 
            };
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl, filters: filters);
            Assert.AreEqual("http://test.com/?title=hello&name=test", result);
        }

        [Test]
        public void GetRequestUrlReturnsOrderBy()
        {
            const string property = "title";
            const OrderByDirection direction = OrderByDirection.Descending;
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl, orderByProperty: property,
                orderByDirection: direction);
            Assert.AreEqual("http://test.com/?order=-title", result);
        }

        [Test]
        public void GetRequestUrlReturnsSkip()
        {
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl, skip: 15);
            Assert.AreEqual("http://test.com/?skip=15", result);
        }

        [Test]
        public void GetRequestUrlReturnsLimit()
        {
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl, limit: 48);
            Assert.AreEqual("http://test.com/?limit=48", result);
        }

        [Test]
        public void GetRequestUrlReturnsLevels()
        {
            var result = ContentfulClient.GetRequestUrl(RequestBaseUrl, includeLevels: 6);
            Assert.AreEqual("http://test.com/?include=6", result);
        }

        private class MockJsonModel
        {
            public string StringValue { get; set; }
            public bool BoolValue { get; set; }
        }
    }
}
