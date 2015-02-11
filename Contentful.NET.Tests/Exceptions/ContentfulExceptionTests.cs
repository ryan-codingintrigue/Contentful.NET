using System;
using Contentful.NET.Exceptions;
using NUnit.Framework;

namespace Contentful.NET.Tests.Exceptions
{
    [TestFixture]
    public class ContentfulExceptionTests
    {
        [Test]
        public void TestCanCreate()
        {
            var exception = new ContentfulException(401, "{ \"message\": \"Unauthorized\" }");
            Assert.AreEqual(401, exception.ErrorCode);
            Assert.AreEqual("Unauthorized", exception.ErrorDetails.Message);
        }
    }
}
