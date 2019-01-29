using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.TsdbOptionsFixtures
{
    [TestFixture]
    public class Given_URI_String_Constructor
    {
        [Test]
        public void When_UsingURI_ThenValidOptionsReturned()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");

            Assert.That(options.OpenTsdbServerUri, Is.EqualTo(new Uri("http://localhost:4242")));
            Assert.That(options.DefaultTags.GetHost(), Is.EqualTo("localhost"));
        }

        [Test]
        public void When_InvaliURI_ThenErrorThrown()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new TsdbOptions(null, "localhost");
            },
                ErrorMessages.SERVER_URI_INVALID);
        }

        [Test]
        public void When_NullHostName_ThenErrorThrown()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    new TsdbOptions(new Uri("http://localhost"), (string) null);
                },
                ErrorMessages.HOST_NAME_INVALID_ERROR_MESSAGE);
        }

        [Test]
        public void When_EmptyHostName_ThenErrorThrown()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    new TsdbOptions(new Uri("http://localhost"), string.Empty);
                },
                ErrorMessages.HOST_NAME_INVALID_ERROR_MESSAGE);
        }

        [Test]
        public void When_ComparedToSameObject_ThenHashCodeEual()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");
            var options2 = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");

            Assert.That(options.GetHashCode(), Is.EqualTo(options2.GetHashCode()));
        }

        [Test]
        public void When_ComparedToSameObject_ThenEqual()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");
            var options2 = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");

            Assert.That(options.Equals(options2), Is.True);
        }
    }
}