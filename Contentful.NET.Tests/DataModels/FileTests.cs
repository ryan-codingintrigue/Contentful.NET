using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class FileTests
    {
        [Test]
        public void TestCanSetFileName()
        {
            var file = new File {FileName = "file.txt"};
            Assert.AreEqual("file.txt", file.FileName);
        }

        [Test]
        public void TestCanSetContentType()
        {
            var file = new File {ContentType = "image/png"};
            Assert.AreEqual("image/png", file.ContentType);
        }
        [Test]
        public void TestCanSetUrl()
        {
            var file = new File() {Url = "http://www.text.com"};
            Assert.AreEqual("http://www.text.com", file.Url);
        }

        [Test]
        public void TestCanSetDetails()
        {
            var details = new {TestProperty = "SampleValue"};
            var file = new File {Details = details};
            Assert.AreEqual(details, file.Details);
        }
    }
}
