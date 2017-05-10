using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.TagsCollectionFixtures
{
    [TestFixture]
    public class Given_DefultConstructor
    {
        private TagsCollection TagsCollection;

        [SetUp]
        public void Setup()
        {
            TagsCollection = new TagsCollection();
        }

        [Test]
        public void Then_DefaultHostNameShouldBeSet()
        {
            Assert.That(TagsCollection.GetHost(), Is.EqualTo(DefaultValues.UNKWNOWN));
        }

        [Test]
        public void When_HostSet_Then_NewValue()
        {
            TagsCollection.SetHost("TestHost");

            Assert.That(TagsCollection.GetHost(), Is.EqualTo("TestHost"));
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        public void When_SetTagWithInvalidValueAndName_Then_ExceptionThrown(string tagName, string tagValue)
        {
            Assert.Throws<ArgumentException>(() => TagsCollection.SetTag(tagName, tagValue));
        }
    }
}