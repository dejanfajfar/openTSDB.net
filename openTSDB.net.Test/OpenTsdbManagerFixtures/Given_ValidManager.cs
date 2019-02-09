using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenTsdbNet;
using OpenTsdbNet.models;
using OpenTsdbNet.Network;

namespace OpenTsdb.Net.Test.OpenTsdbManagerFixtures
{
    [TestClass]
    public class Given_ValidManager
    {
        private IOpenTsdbManager manager;
        private Mock<IOpenTsdbNetworkBridge> bridgeMock;
        
        [TestInitialize]
        public void Setup()
        {
            bridgeMock = new Mock<IOpenTsdbNetworkBridge>();
            manager = new OpenTsdbManager(TsdbOptions.New("http://localhost"), bridgeMock.Object);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void PushAsyncShorthand_InvalidName_ArgumentException(string nameInput)
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            {
                await manager.PushAsync(nameInput, 42);
            });
        }

        [TestMethod]
        public void PushAsyncDataPoint_NullDataPoint_ArgumentNullException()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException> (async () =>
            {
                await manager.PushAsync((DataPoint<int>)null);
            });
        }

        [TestMethod]
        public void PushAsyncDataPoints_NullDataPoints_ArgumentNullException()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            {
                await manager.PushAsync((IList<DataPoint<int>>)null);
            });
        }
    }
}