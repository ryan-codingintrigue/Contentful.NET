using System;
using NUnit.Framework;

namespace Contentful.NET.Tests
{
    [TestFixture]
    public class ImageHelperTests
    {
        [Test]
        public void TestReturnsBaseUrlWhenNoParametersPassed()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl);
            Assert.AreEqual(baseUrl, resized);
        }

        [Test]
        public void TestReturnsSingleWidth()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl, 150);
            Assert.AreEqual("http://image.contentful.com?w=150", resized);
        }

        [Test]
        public void TestReturnsSingleHeight()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl, height: 150);
            Assert.AreEqual("http://image.contentful.com?h=150", resized);
        }

        [Test]
        public void TestReturnsWidthAndHeight()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl, 200, 100);
            Assert.AreEqual("http://image.contentful.com?w=200&h=100", resized);
        }

        [Test]
        public void TestReturnsSingleJpg()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl, type: ImageHelper.ImageType.Jpg);
            Assert.AreEqual("http://image.contentful.com?fm=jpg", resized);
        }

        [Test]
        public void TestReturnsJpegWithCompression()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl, type: ImageHelper.ImageType.Jpg, jpegCompression: 90);
            Assert.AreEqual("http://image.contentful.com?fm=jpg&q=90", resized);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidJpegCompression()
        {
            const string baseUrl = "http://image.contentful.com";
            var resized = ImageHelper.GetResizedImageUrl(baseUrl, type: ImageHelper.ImageType.Jpg, jpegCompression: 101);
        }
    }
}
