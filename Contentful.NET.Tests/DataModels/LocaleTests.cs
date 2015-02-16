using Contentful.NET.DataModels;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class LocaleTests
    {
        [Test]
        public void TestCanSetName()
        {
            const string name = "English (US)";
            var locale = new Locale
            {
                Name = name
            };
            Assert.AreEqual(name, locale.Name);
        }

        [Test]
        public void TestCanSetCode()
        {
            const string code = "en-US";
            var locale = new Locale
            {
                Code = code
            };
            Assert.AreEqual(code, locale.Code);
        }
    }
}
