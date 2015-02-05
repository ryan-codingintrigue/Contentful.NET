using System;
using Contentful.NET.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.DataModels
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public void TestCanSetFileName()
        {
            var file = new File {FileName = "file.txt"};
            Assert.AreEqual("file.txt", file.FileName);
        }

        [TestMethod]
        public void TestCanSetContentType()
        {
            var file = new File {ContentType = "image/png"};
            Assert.AreEqual("image/png", file.ContentType);
        }
        [TestMethod]
        public void TestCanSetUrl()
        {
            var file = new File() {Url = "http://www.text.com"};
            Assert.AreEqual("http://www.text.com", file.Url);
        }

        [TestMethod]
        public void TestCanSetDetails()
        {
            var details = new {TestProperty = "SampleValue"};
            var file = new File {Details = details};
            Assert.AreEqual(details, file.Details);
        }
    }
}
