using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class ContentTypeTests
    {
        [Test]
        public void TestCanSetName()
        {
            var contentType = new ContentType {Name = "test"};
            Assert.AreEqual("test", contentType.Name);
        }

        [Test]
        public void TestCanSetDescription()
        {
            var contentType = new ContentType {Description = "test description"};
            Assert.AreEqual("test description", contentType.Description);
        }
    }
}
