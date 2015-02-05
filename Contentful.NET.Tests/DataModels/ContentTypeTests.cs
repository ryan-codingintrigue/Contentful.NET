using System;
using Contentful.NET.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.DataModels
{
    [TestClass]
    public class ContentTypeTests
    {
        [TestMethod]
        public void TestCanSetName()
        {
            var contentType = new ContentType {Name = "test"};
            Assert.AreEqual("test", contentType.Name);
        }

        [TestMethod]
        public void TestCanSetDescription()
        {
            var contentType = new ContentType {Description = "test description"};
            Assert.AreEqual("test description", contentType.Description);
        }
    }
}
