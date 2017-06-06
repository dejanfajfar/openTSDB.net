using System;
using NUnit.Framework;
using openTSDB.net.Models;
using openTSDB.net.Network;

namespace openTSDB.net.Tests.OpenTsdbManagerFixtures
{
    [TestFixture]
    public class Given_InvalidConstructorData
    {
        [Test]
        public void When_NullOptions_Then_ArgumentNullException()
        {
            Assert.That(() => { new OpenTsdbManager(null, new OpenTsdbIntegration(new Uri("http://localhost"))); }, Throws.ArgumentNullException);
        }
        
        [Test]
        public void When_NullNetworkBridge_Then_ArgumentNullException()
        {
            Assert.That(() => { new OpenTsdbManager(new TsdbOptions(new Uri("http://localhost"), "test"), null); }, Throws.ArgumentNullException);
        }
    }
}