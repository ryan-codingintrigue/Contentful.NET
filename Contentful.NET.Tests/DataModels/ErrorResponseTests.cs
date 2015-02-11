using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class ErrorResponseTests
    {
        [Test]
        public void TestCanSetMessage()
        {
            var errorResponse = new ErrorResponse {Message = "Test"};
            Assert.AreEqual("Test", errorResponse.Message);
        }

        [Test]
        public void TestCanSetRequestId()
        {
            var errorResponse = new ErrorResponse {RequestId = "15"};
            Assert.AreEqual("15", errorResponse.RequestId);
        }

        [Test]
        public void TestCanSetSystemProperties()
        {
            var systemProperty = new SystemProperties();
            var errorResponse = new ErrorResponse {SystemProperties = systemProperty};
            Assert.AreEqual(systemProperty, errorResponse.SystemProperties);
        }
    }
}
