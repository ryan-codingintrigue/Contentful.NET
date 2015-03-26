using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests
{
    [TestFixture]
    public class RestEndpointResolverTests
    {
        [Test]
        public void CanGetAssetEndpoint()
        {
            var endpoint = RestEndpointResolver.GetEndpointUrl<Asset>("spaceId");
            const string expectedEndpoint = "https://cdn.contentful.com/spaces/spaceId/assets/";
            Assert.AreEqual(expectedEndpoint, endpoint);
        }

        [Test]
        public void CanGetContentTypeEndpoint()
        {
            var endpoint = RestEndpointResolver.GetEndpointUrl<ContentType>("spaceId");
            const string expectedEndpoint = "https://cdn.contentful.com/spaces/spaceId/content_types/";
            Assert.AreEqual(expectedEndpoint, endpoint);
        }

        [Test]
        public void CanGetEntryEndpoint()
        {
            var endpoint = RestEndpointResolver.GetEndpointUrl<Entry>("spaceId");
            const string expectedEndpoint = "https://cdn.contentful.com/spaces/spaceId/entries/";
            Assert.AreEqual(expectedEndpoint, endpoint);
        }

        [Test]
        public void CanGetSpaceEndpoint()
        {
            var endpoint = RestEndpointResolver.GetEndpointUrl<Space>("spaceId");
            const string expectedEndpoint = "https://cdn.contentful.com/spaces/spaceId";
            Assert.AreEqual(expectedEndpoint, endpoint);
        }

		[Test]
		public void CanGetSpaceEndpointForPreview()
		{
			var endpoint = RestEndpointResolver.GetEndpointUrl<Space>("spaceId", true);
			const string expectedEndpoint = "https://preview.contentful.com/spaces/spaceId";
			Assert.AreEqual(expectedEndpoint, endpoint);
		}
    }
}
