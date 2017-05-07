using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests
{
    [TestFixture]
    public class TagsCollectionExtentionsFixture
    {
        private TagsCollection tags;

        private const string TEST_HOSTNAME = "TestHost";
        private const string TEST_TAG_NAME = "TestTag";
        private const string TEST_TAG_VALUE = "TestValue";

        [SetUp]
        public void SetUp()
        {
            tags = new TagsCollection();
        }

        [Test]
        public void Given_EmptyTagCollection_When_SetHostWithClearTextName_Then_HostNameSet()
        {
            tags.SetHost(TEST_HOSTNAME);

            Assert.That(tags, Is.Not.Empty);
            Assert.True(tags.ContainsKey(TagNames.HOST));
            Assert.That(tags[TagNames.HOST], Is.EqualTo(TEST_HOSTNAME));
        }

        [Test]
        public void Given_NonEmptyTagCollection_When_SetHostWithClearTextName_Then_HostNameSet()
        {
            tags.SetHost(TEST_HOSTNAME);

            tags.SetHost("TestHost2");

            Assert.That(tags, Is.Not.Empty);
            Assert.True(tags.ContainsKey(TagNames.HOST));
            Assert.That(tags[TagNames.HOST], Is.EqualTo("TestHost2"));
        }

        [Test]
        public void Given_EmptyTagCollection_When_SetTag_Then_TagSet()
        {
            tags.SetTag(TEST_TAG_NAME, TEST_TAG_VALUE);

            Assert.That(tags, Is.Not.Empty);
            Assert.True(tags.ContainsKey(TEST_TAG_NAME));
            Assert.That(tags[TEST_TAG_NAME], Is.EqualTo(TEST_TAG_VALUE));
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        public void Given_EmptyTagCollection_When_SetTagWithInvalidValueAndName_Then_ExceptionThrown(string tagName, string tagValue)
        {
            Assert.Throws<ArgumentException>(() => tags.SetTag(tagName, tagValue));
        }
    }
}