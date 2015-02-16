using System.Collections.Generic;
using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class SearchResultTests
    {
        [Test]
        public void TestCanSetTotal()
        {
            var searchResult = new SearchResult<Entry>()
            {
                Total = 16
            };
            Assert.AreEqual(16, searchResult.Total);
        }

        [Test]
        public void TestCanSetSkip()
        {
            var searchResult = new SearchResult<Entry>
            {
                Skip = 19
            };
            Assert.AreEqual(19, searchResult.Skip);
        }

        [Test]
        public void TestCanSetLimit()
        {
            var searchResult = new SearchResult<Asset>
            {
                Limit = 29
            };
            Assert.AreEqual(29, searchResult.Limit);
        }

        [Test]
        public void TestCanSetItems()
        {
            var items = GetEnumerableAssets();
            var searchResult = new SearchResult<Asset>
            {
                Items = items
            };
            Assert.AreSame(items, searchResult.Items);
        }

        [Test]
        public void TestCanSetIncludes()
        {
            var includes = new Includes
            {
                Assets = GetEnumerableAssets()
            };
            var searchResult = new SearchResult<Asset>
            {
                Includes = includes
            };
            Assert.AreSame(includes, searchResult.Includes);
        }

        private static IEnumerable<Asset> GetEnumerableAssets()
        {
            return new[]
            {
                new Asset
                {
                    Details = new AssetDetails
                    {
                        Title = "Asset 1"
                    }
                },
                new Asset
                {
                    Details = new AssetDetails
                    {
                        Title = "Asset 2"
                    }
                }
            };
        }
    }
}
