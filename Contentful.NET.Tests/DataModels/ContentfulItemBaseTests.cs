using System;
using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class ContentfulItemBaseTests
    {
        [Test]
        public void TestCanSetSystemProperties()
        {
            var sysProperties = new SystemProperties()
            {
                CreatedDateTime = DateTime.Now,
                Locale = "en-US"
            };
            var mock = new ContentfulItemBaseMock {SystemProperties = sysProperties};
            Assert.AreEqual(sysProperties, mock.SystemProperties);
        }

        private class ContentfulItemBaseMock : ContentfulItemBase
        {
            
        }
    }
}
