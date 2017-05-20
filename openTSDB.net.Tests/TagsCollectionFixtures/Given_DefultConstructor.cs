using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.TagsCollectionFixtures
{
    [TestFixture]
    public class Given_DefultConstructor
    {
        private TagsCollection tagsCollection;

        [SetUp]
        public void Setup()
        {
            tagsCollection = new TagsCollection();
        }

        [Test]
        public void Then_DefaultHostNameShouldBeSet()
        {
            Assert.That(tagsCollection.GetHost(), Is.EqualTo(TagsCollection.UNKWNOWN));
        }

        [Test]
        public void When_HostSet_Then_NewValue()
        {
            tagsCollection.SetHost("TestHost");

            Assert.That(tagsCollection.GetHost(), Is.EqualTo("TestHost"));
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        public void When_SetTagWithInvalidValueAndName_Then_ExceptionThrown(string tagName, string tagValue)
        {
            Assert.Throws<ArgumentException>(() => tagsCollection.SetTag(tagName, tagValue));
        }
    }
}