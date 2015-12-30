using NUnit.Framework;
using openTsdbNet.models;

namespace openTsdbNet.Tests
{
    [TestFixture]
    public class TagsCollectionExtentionsFixture
    {
        [Test]
        public void Given_EmptyTagCollection_When_SetHostWithClearTextName_Then_HostNameSet()
        {
            var tags = new TagsCollection();
            tags.SetHost("TestHost");

            Assert.That(tags, Is.Not.Empty);
            Assert.True(tags.ContainsKey(TagNames.HOST));
            Assert.That(tags[TagNames.HOST], Is.EqualTo("TestHost"));
        }

        [Test]
        public void Given_EmptyTagCollection_When_SetHostWithNameProvider_Then_HostNameSet()
        {
            
        }
    }
}