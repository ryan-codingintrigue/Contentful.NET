using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class IncludeTests
    {
        [Test]
        public void TestCanSetAssets()
        {
            var assets = new[]
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
            var includes = new Includes
            {
                Assets = assets
            };
            Assert.AreSame(assets, includes.Assets);
        }

        [Test]
        public void TestCanSetEntries()
        {
            var entries = new[]
            {
                new Entry
                {
                    Fields = new {},
                    SystemProperties = new SystemProperties()
                }
            };
            var includes = new Includes
            {
                Entries = entries
            };
            Assert.AreSame(entries, includes.Entries);
        }
    }
}
