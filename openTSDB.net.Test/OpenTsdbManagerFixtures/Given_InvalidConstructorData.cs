using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openTSDB.net;
using openTSDB.net.Models;
using openTSDB.net.Network;

namespace OpenTsdb.Net.Test.OpenTsdbManagerFixtures
{
    [TestClass]
    public class Given_InvalidConstructorData
    {
        [TestMethod]
        public void When_NullOptions_Then_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new OpenTsdbManager(null, new OpenTsdbIntegration(new Uri("http://localhost")));
            });
        }
        
        [TestMethod]
        public void When_NullNetworkBridge_Then_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new OpenTsdbManager(new TsdbOptions(new Uri("http://localhost"), "test"), null);
            });
        }
    }
}