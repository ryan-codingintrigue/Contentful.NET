using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class AssetDetailTests
    {
        [Test]
        public void CanSetTitle()
        {
            const string expectedTitle = "description";
            var assetDetail = new AssetDetails
            {
                Title = expectedTitle
            };
            Assert.AreEqual(expectedTitle, assetDetail.Title);
        }

        [Test]
        public void CanSetDescription()
        {
            const string expectedDescription = "test description";
            var assetDetail = new AssetDetails
            {
                Description = expectedDescription
            };
            Assert.AreEqual(expectedDescription, assetDetail.Description);
        }

        [Test]
        public void CanSetFile()
        {
            var file = new File
            {
                ContentType = "application/png",
                FileName = "image.png",
                Url = "http://image.com/image.png"
            };
            var assetDetail = new AssetDetails
            {
                File = file
            };
            Assert.AreSame(file, assetDetail.File);
        }
    }
}
