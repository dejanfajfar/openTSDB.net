using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.TagsCollectionFixtures
{
    [TestFixture]
    public class Given_HostName
    {
        private TagsCollection tagsCollection;
        private readonly string HostName = "TestHostName";
        private readonly string TagName = "TestTagName";
        private readonly string TagValue = "42";

        [SetUp]
        public void Setup()
        {
            tagsCollection = new TagsCollection(HostName);
        }

        [Test]
        public void Then_HostNameSet()
        {
            Assert.That(tagsCollection[TagsCollection.HOST], Is.EqualTo(HostName));
        }

        [Test]
        public void When_ProvidingNewHostName_Then_NewHostNameTaken()
        {
            tagsCollection.SetHost("NewName");

            Assert.That(tagsCollection[TagsCollection.HOST], Is.EqualTo("NewName"));
        }

        [Test]
        public void When_AddNewTag_Then_NewTagAdded()
        {
            tagsCollection.Add(TagName, TagValue);

            Assert.That(tagsCollection.ContainsKey(TagName), Is.True);
            Assert.That(tagsCollection[TagName], Is.EqualTo(TagValue));
        }

        [Test]
        public void When_TagValueOverriden_Then_ArgumentExceptionThrown()
        {
            tagsCollection.Add(TagName, TagValue);

            Assert.That(tagsCollection.ContainsKey(TagName), Is.True);


            Assert.Throws<ArgumentException>(() => { tagsCollection.Add(TagName, "43"); });
        }

        [Test]
        public void When_ExtendedWithANonColidingCollection_Then_BouthTagCollectionJoined()
        {
            var extendedCollection = tagsCollection.ExtendWith(new TagsCollection
            {
                {"01", "01"},
                {"02", "02"}
            });

            Assert.That(extendedCollection.ContainsKey(TagsCollection.HOST), Is.True);
            Assert.That(extendedCollection.ContainsKey("01"), Is.True);
            Assert.That(extendedCollection.ContainsKey("02"), Is.True);
        }
    }
}