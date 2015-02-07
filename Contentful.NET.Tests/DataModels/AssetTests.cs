using System;
using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class AssetTests
    {
        [Test]
        public void TestCanSetDetails()
        {
            var assetDetails = new AssetDetails();
            assetDetails.Description = "Description";
            assetDetails.File = new File()
            {
                ContentType = "image/png",
                Details = new {},
                FileName = "test.png",
                Url = "http://test.com/test.png",
                SystemProperties = new SystemProperties()
                {
                    Id = "testId"
                }
            };
            var asset = new Asset {Details = assetDetails};
            Assert.AreEqual(assetDetails, asset.Details);
        }
    }
}
