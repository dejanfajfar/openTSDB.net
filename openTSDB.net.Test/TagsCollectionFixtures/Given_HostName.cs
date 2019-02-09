using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTsdbNet;
using OpenTsdbNet.models;

namespace OpenTsdb.Net.Test.TagsCollectionFixtures
{
    [TestClass]
    public class Given_HostName
    {
        private TagsCollection tagsCollection;
        private readonly string HostName = "TestHostName";
        private readonly string TagName = "TestTagName";
        private readonly string TagValue = "42";

        [TestInitialize]
        public void Setup()
        {
            tagsCollection = TagsCollection.New(HostName);
        }

        [TestMethod]
        public void Then_HostNameSet()
        {
            Assert.AreEqual(tagsCollection[TagsCollection.HOST],HostName);
        }
        
        [TestMethod]
        public void Then_MarkedAsArtificialHost()
        {
            Assert.AreEqual(tagsCollection[TagsCollection.HOST_ARTIFICIAL], "true");   
        }

        [TestMethod]
        public void When_ProvidingNewHostName_Then_NewHostNameTaken()
        {
            tagsCollection.SetHost("NewName");

            Assert.AreEqual(tagsCollection[TagsCollection.HOST], "NewName");
        }

        [TestMethod]
        public void When_AddNewTag_Then_NewTagAdded()
        {
            tagsCollection.Add(TagName, TagValue);

            Assert.IsTrue(tagsCollection.ContainsKey(TagName));
            Assert.AreEqual(tagsCollection[TagName], TagValue);
        }

        [TestMethod]
        public void When_TagValueOverriden_Then_ArgumentExceptionThrown()
        {
            tagsCollection.Add(TagName, TagValue);

            Assert.IsTrue(tagsCollection.ContainsKey(TagName));


            Assert.ThrowsException<ArgumentException>(() => { tagsCollection.Add(TagName, "43"); });
        }

        [TestMethod]
        public void When_ExtendedWithANonCollidingCollection_Then_BoughTagCollectionJoined()
        {
            var deltaCollection = TagsCollection
                .New()
                .SetTag("01", "01")
                .SetTag("02", "02");
            
            var extendedCollection = tagsCollection.ExtendWith(deltaCollection);

            Assert.IsTrue(extendedCollection.ContainsKey(TagsCollection.HOST));
            Assert.IsTrue(extendedCollection.ContainsKey("01"));
            Assert.IsTrue(extendedCollection.ContainsKey("02"));
        }
    }
}