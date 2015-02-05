using System;
using Contentful.NET.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.DataModels
{
    [TestClass]
    public class SpaceTests
    {
        [TestMethod]
        public void TestCanSetName()
        {
            var space = new Space {Name = "test"};
            Assert.AreEqual("test", space.Name);
        }
    }
}
