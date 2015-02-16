using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class SystemPropertiesTests
    {
        [Test]
        public void TestCanSetId()
        {
            var expectedId = Guid.NewGuid().ToString();
            var sysProperties = new SystemProperties
            {
                Id = expectedId
            };
            Assert.AreEqual(expectedId, sysProperties.Id);
        }

        [Test]
        public void TestCanSetLinkType()
        {
            const string expectedLinkType = "Entry";
            var sysProperties = new SystemProperties()
            {
                LinkType = expectedLinkType
            };
            Assert.AreEqual(expectedLinkType, sysProperties.LinkType);
        }

        [Test]
        public void TestCanSetType()
        {
            const string expectedType = "Asset";
            var sysProperties = new SystemProperties
            {
                Type = expectedType
            };
            Assert.AreEqual(expectedType, sysProperties.Type);
        }

        [Test]
        public void CanSetSpace()
        {
            var space = new Link
            {
               
            };
            var sysProperties = new SystemProperties
            {
                Space = space
            };
            Assert.AreSame(space, sysProperties.Space);
        }

        [Test]
        public void CanSetContentType()
        {
            var contentType = new Link();
            var sysProperties = new SystemProperties
            {
                ContentType = contentType
            };
            Assert.AreSame(contentType, sysProperties.ContentType);
        }

        [Test]
        public void TestCanSetRevision()
        {
            const int revision = 1;
            var sysProperties = new SystemProperties
            {
                Revision = revision
            };
            Assert.AreEqual(revision, sysProperties.Revision);
        }

        [Test]
        public void TestCanSetNullRevision()
        {
            var sysProperties = new SystemProperties
            {
                Revision = null
            };
            Assert.IsNull(sysProperties.Revision);
        }

        [Test]
        public void CanSetCreatedAt()
        {
            var createdAt = DateTime.Now;
            var sysProperties = new SystemProperties
            {
                CreatedDateTime = createdAt
            };
            Assert.AreEqual(createdAt, sysProperties.CreatedDateTime);
        }

        [Test]
        public void CanSetNullCreatedAt()
        {
            var sysProperties = new SystemProperties
            {
                CreatedDateTime = null
            };
            Assert.IsNull(sysProperties.CreatedDateTime);
        }

        [Test]
        public void CanSetUpdatedAt()
        {
            var updatedAt = DateTime.Now;
            var sysProperties = new SystemProperties
            {
                UpdatedDateTime = updatedAt
            };
            Assert.AreEqual(updatedAt, sysProperties.UpdatedDateTime);
        }

        [Test]
        public void CanSetNullUpdatedAt()
        {
            var sysProperties = new SystemProperties
            {
                UpdatedDateTime = null
            };
            Assert.IsNull(sysProperties.UpdatedDateTime);
        }

        [Test]
        public void CanSetLocale()
        {
            const string locale = "en-US";
            var sysProperties = new SystemProperties
            {
                Locale = locale
            };
            Assert.AreEqual(locale, sysProperties.Locale);
        }
    }
}
