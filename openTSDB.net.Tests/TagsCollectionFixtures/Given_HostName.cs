using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.TagsCollectionFixtures
{
    [TestFixture]
    public class Given_HostName
    {
        private TagsCollection TagsCollection;
        private readonly string HostName = "TestHostName";
        private readonly string TagName = "TestTagName";
        private readonly string TagValue = "42";

        [SetUp]
        public void Setup()
        {
            TagsCollection = new TagsCollection(HostName);
        }

        [Test]
        public void Then_HostNameSet()
        {
            Assert.That(TagsCollection[DefaultValues.Tags.HOST], Is.EqualTo(HostName));
        }

        [Test]
        public void When_ProvidingNewHostName_Then_NewHostNameTaken()
        {
            TagsCollection.SetHost("NewName");

            Assert.That(TagsCollection[DefaultValues.Tags.HOST], Is.EqualTo("NewName"));
        }

        [Test]
        public void When_AddNewTag_Then_NewTagAdded()
        {
            TagsCollection.Add(TagName, TagValue);

            Assert.That(TagsCollection.ContainsKey(TagName), Is.True);
            Assert.That(TagsCollection[TagName], Is.EqualTo(TagValue));
        }

        [Test]
        public void When_TagValueOverriden_Then_ArgumentExceptionThrown()
        {
            TagsCollection.Add(TagName, TagValue);

            Assert.That(TagsCollection.ContainsKey(TagName), Is.True);


            Assert.Throws<ArgumentException>(() => { TagsCollection.Add(TagName, "43"); });
        }
    }
}