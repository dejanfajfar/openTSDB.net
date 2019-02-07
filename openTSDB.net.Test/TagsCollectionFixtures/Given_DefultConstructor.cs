using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTsdbNet;
using OpenTsdbNet.models;

namespace OpenTsdb.Net.Test.TagsCollectionFixtures
{
    [TestClass]
    public class GivenDefaultConstructor
    {
        private TagsCollection tagsCollection;

        [TestInitialize]
        public void Setup()
        {
            tagsCollection = new TagsCollection();
        }

        [TestMethod]
        public void Then_DefaultHostNameShouldBeSet()
        {
            Assert.AreEqual(Environment.MachineName, tagsCollection.GetHost());
        }

        [TestMethod]
        public void When_HostSet_Then_NewValue()
        {
            tagsCollection.SetHost("TestHost");

            Assert.AreEqual(tagsCollection.GetHost(), "TestHost");
        }

        [TestMethod]
        public void When_ComparedToSelf_ThenEqual()
        {
            Assert.IsTrue(tagsCollection.Equals(tagsCollection));
        }

        [TestMethod]
        public void When_ComparedToSame_ThenEqual()
        {
            Assert.IsTrue(tagsCollection.Equals(new TagsCollection()));
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow(null, null)]
        [DataRow(null, "")]
        [DataRow("", null)]
        public void When_SetTagWithInvalidValueAndName_Then_ExceptionThrown(string tagName, string tagValue)
        {
            Assert.ThrowsException<ArgumentException>(() => tagsCollection.SetTag(tagName, tagValue));
        }
    }
}