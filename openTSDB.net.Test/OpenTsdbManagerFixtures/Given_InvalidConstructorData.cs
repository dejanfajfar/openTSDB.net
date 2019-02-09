using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTsdbNet;
using OpenTsdbNet.models;
using OpenTsdbNet.Network;

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
                new OpenTsdbManager(TsdbOptions.New("http://localhost"), null);
            });
        }
    }
}