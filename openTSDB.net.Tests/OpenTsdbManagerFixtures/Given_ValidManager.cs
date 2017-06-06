using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using openTSDB.net.Models;
using openTSDB.net.Network;

namespace openTSDB.net.Tests.OpenTsdbManagerFixtures
{
    [TestFixture]
    public class Given_ValidManager
    {
        private IOpenTsdbManager manager;
        private Mock<IOpenTsdbNetworkBridge> bridgeMock;
        
        [SetUp]
        public void Setup()
        {
            bridgeMock = new Mock<IOpenTsdbNetworkBridge>();
            manager = new OpenTsdbManager(new TsdbOptions(new Uri("http://localhost"), "test"), bridgeMock.Object);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void PushAsyncShorthand_InvalidName_ArgumentException(string nameInput)
        {
            Assert.That(async () =>
            {
                await manager.PushAsync(nameInput, 42);
            }, Throws.ArgumentException);
        }

        [Test]
        public void PushAsyncDataPoint_NullDataPoint_ArgumentNullException()
        {
            Assert.That(async () =>
            {
                await manager.PushAsync((DataPoint<int>)null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void PushAsyncDataPoints_NullDataPoints_ArgumentNullException()
        {
            Assert.That(async () =>
            {
                await manager.PushAsync((IList<DataPoint<int>>)null);
            }, Throws.ArgumentNullException);
        }
    }
}