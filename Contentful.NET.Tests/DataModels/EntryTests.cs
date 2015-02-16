using System;
using Contentful.NET.DataModels;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Contentful.NET.Tests.DataModels
{
    [TestFixture]
    public class EntryTests
    {
        private static readonly DateTime TestDate = DateTime.Now;

        [Test]
        public void CanSetFields()
        {
            var entry = GetPopulatedEntry();
            Assert.AreEqual("hello!", entry.Fields.my_custom_string);
        }

        [Test]
        public void TestCanGetType()
        {
            var entry = GetPopulatedEntry();
            var type = entry.GetType<int>("my_custom_int");
            Assert.IsInstanceOf<int>(type);
            Assert.AreEqual(15, type);
        }

        [Test]
        public void TestCanGetString()
        {
            var entry = GetPopulatedEntry();
            var str = entry.GetString("my_custom_string");
            Assert.IsInstanceOf<string>(str);
            Assert.AreEqual("hello!", str);
        }

        [Test]
        public void TestCanGetBoolean()
        {
            var entry = GetPopulatedEntry();
            var boolValue = entry.GetBoolean("my_custom_bool");
            Assert.IsInstanceOf<bool?>(boolValue);
            Assert.IsNotNull(boolValue);
            Assert.IsTrue(boolValue.Value);
        }

        [Test]
        public void TestCanGetNullableBoolean()
        {
            var entry = GetPopulatedEntry();
            var nullValue = entry.GetBoolean("my_custom_nullable_bool");
            Assert.IsNull(nullValue);
        }

        [Test]
        public void TestCanGetDateTime()
        {
            var entry = GetPopulatedEntry();
            var dateValue = entry.GetDateTime("my_custom_datetime");
            Assert.IsInstanceOf<DateTime?>(dateValue);
            Assert.IsNotNull(dateValue);
            Assert.AreEqual(TestDate, dateValue);
        }

        [Test]
        public void TestCanGetNullableDateTime()
        {
            var entry = GetPopulatedEntry();
            var dateValue = entry.GetDateTime("my_custom_nullable_datetime");
            Assert.IsNull(dateValue);
        }

        [Test]
        public void TestCanGetStringArray()
        {
            var entry = GetPopulatedEntry();
            var stringArray = entry.GetArray("my_custom_string_array");
            Assert.IsInstanceOf<string[]>(stringArray);
            Assert.IsNotNull(stringArray);
            CollectionAssert.AreEquivalent(stringArray, new[] { "one", "two", "three" });
        }

        [Test]
        public void TestCanGetLink()
        {
            var expectedLink = new Link
            {
                SystemProperties = new SystemProperties
                {
                    LinkType = "Asset",
                    Id = "assetId"
                }
            };
            var entry = GetPopulatedEntry(expectedLink);
            var link = entry.GetLink("link");
            Assert.NotNull(link);
            Assert.IsInstanceOf<Link>(link);
            Assert.NotNull(link.SystemProperties);
            Assert.AreEqual("assetId", link.SystemProperties.Id);
            Assert.AreEqual("Asset", link.SystemProperties.LinkType);
        }

        [Test]
        public void TestCanGetLocation()
        {
            var expectedLocation = new Location
            {
                Latitude = 45,
                Longitude = 60
            };
            var entry = GetPopulatedEntry(location: expectedLocation);
            var location = entry.GetLocation("location");
            Assert.IsNotNull(location);
            Assert.IsInstanceOf<Location>(location);
            Assert.AreEqual(expectedLocation.Latitude, location.Latitude);
            Assert.AreEqual(expectedLocation.Longitude, location.Longitude);
        }

        private static Entry GetPopulatedEntry(Link link = null, Location location = null)
        {
            return new Entry
            {
                Fields = new
                {
                    link,
                    location,
                    my_custom_nullable_datetime = default(DateTime?),
                    my_custom_nullable_bool = default(bool?),
                    my_custom_string = "hello!",
                    my_custom_int = 15,
                    my_custom_bool = true,
                    my_custom_datetime = TestDate,
                    my_custom_string_array = new []
                    {
                        "one", "two", "three"
                    },
                    my_custom_object = new
                    {
                        one = 1,
                        two = "two"
                    }
                }
            };
        }
    }
}
