using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.TsdbOptionsFixtures
{
    [TestFixture]
    public class Given_URI_TagCollection_Constructor
    {
        [Test]
        public void When_DefaultTagCollection_Then_Host_Unknown()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), new TagsCollection());

            Assert.That(options.OpenTsdbServerUri, Is.EqualTo(new Uri("http://localhost:4242")));
            Assert.That(options.DefaultTags.GetHost(), Is.EqualTo(TagsCollection.UNKWNOWN));
        }

        [Test]
        public void When_UriAndHost_ThenAllInitialized()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), new TagsCollection("localhost"));

            Assert.That(options.OpenTsdbServerUri, Is.EqualTo(new Uri("http://localhost:4242")));
            Assert.That(options.DefaultTags.GetHost(), Is.EqualTo("localhost"));
        }

        [Test]
        public void When_InvaliURINull_ThenErrorThrown()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    new TsdbOptions(null, "localhost");
                },
                ErrorMessages.SERVER_URI_INVALID);
        }

        [Test]
        public void When_TagCollectionNull_ThenErrorThrown()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    new TsdbOptions(new Uri("http://localhost:4242"), (TagsCollection) null);
                },
                ErrorMessages.TAG_COLLECTION_NULL);
        }
    }
}