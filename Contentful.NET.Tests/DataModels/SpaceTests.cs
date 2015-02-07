using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class SpaceTests
    {
        [Test]
        public void TestCanSetName()
        {
            var space = new Space {Name = "test"};
            Assert.AreEqual("test", space.Name);
        }
    }
}
