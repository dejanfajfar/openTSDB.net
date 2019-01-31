using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openTSDB.net;
using openTSDB.net.Models;

namespace OpenTsdb.Net.Test.TsdbOptionsFixtures
{
    [TestClass]
    public class Given_URI_TagCollection_Constructor
    {
        [TestMethod]
        public void When_DefaultTagCollection_Then_Host_Unknown()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), new TagsCollection());

            Assert.AreEqual(options.OpenTsdbServerUri, new Uri("http://localhost:4242"));
            Assert.AreEqual(options.DefaultTags.GetHost(), TagsCollection.UNKWNOWN);
        }

        [TestMethod]
        public void When_UriAndHost_ThenAllInitialized()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), new TagsCollection("localhost"));

            Assert.AreEqual(options.OpenTsdbServerUri, new Uri("http://localhost:4242"));
            Assert.AreEqual(options.DefaultTags.GetHost(), "localhost");
        }

        [TestMethod]
        public void When_InvaliURINull_ThenErrorThrown()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    new TsdbOptions(null, "localhost");
                },
                ErrorMessages.SERVER_URI_INVALID);
        }

        [TestMethod]
        public void When_TagCollectionNull_ThenErrorThrown()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    new TsdbOptions(new Uri("http://localhost:4242"), (TagsCollection) null);
                },
                ErrorMessages.TAG_COLLECTION_NULL);
        }
    }
}