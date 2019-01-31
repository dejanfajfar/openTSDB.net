using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openTSDB.net;
using OpenTsdbNet;
using OpenTsdbNet.models;

namespace OpenTsdb.Net.Test.TsdbOptionsFixtures
{
    [TestClass]
    public class Given_URI_String_Constructor
    {
        [TestMethod]
        public void When_UsingURI_ThenValidOptionsReturned()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");

            Assert.AreEqual(options.OpenTsdbServerUri, new Uri("http://localhost:4242"));
            Assert.AreEqual(options.DefaultTags.GetHost(), "localhost");
        }

        [TestMethod]
        public void When_InvalidURI_ThenErrorThrown()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new TsdbOptions(null, "localhost");
            },
                ErrorMessages.SERVER_URI_INVALID);
        }

        [TestMethod]
        public void When_NullHostName_ThenErrorThrown()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    new TsdbOptions(new Uri("http://localhost"), (string) null);
                },
                ErrorMessages.HOST_NAME_INVALID_ERROR_MESSAGE);
        }

        [TestMethod]
        public void When_EmptyHostName_ThenErrorThrown()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    new TsdbOptions(new Uri("http://localhost"), string.Empty);
                },
                ErrorMessages.HOST_NAME_INVALID_ERROR_MESSAGE);
        }

        [TestMethod]
        public void When_ComparedToSameObject_ThenHashCodeEual()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");
            var options2 = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");

            Assert.AreEqual(options.GetHashCode(), options2.GetHashCode());
        }

        [TestMethod]
        public void When_ComparedToSameObject_ThenEqual()
        {
            var options = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");
            var options2 = new TsdbOptions(new Uri("http://localhost:4242"), "localhost");

            Assert.IsTrue(options.Equals(options2));
        }
    }
}