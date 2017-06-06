using System;
using System.IO;
using Epoch.net;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.DataPointFixtures
{
    [TestFixture]
    public class StringSerializationFixture
    {
        [Test]
        public void SerializeDataPoint()
        {
            var sampleDataPoint = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, @"DataPointFixtures/DataPointSample.json"));

            var dataPoint = new DataPoint<int>
            {
                Value = 15,
                Metric = "testMetric",
                Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToEpoch(),
                Tags = new TagsCollection("testHost")
            };

            Assert.That(dataPoint.Stringify(), Is.EqualTo(sampleDataPoint));
        }

        [Test]
        public void SerializeListOfDataPoints()
        {
            var sampleDataPoints = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, @"DataPointFixtures/DataPointListSample.json"));

            var dataPoints = new[]
            {
                new DataPoint<int>
                {
                    Value = 15,
                    Metric = "testMetric",
                    Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToEpoch(),
                    Tags = new TagsCollection("testHost")
                },
                new DataPoint<int>
                {
                    Value = 14,
                    Metric = "testMetric",
                    Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToEpoch(),
                    Tags = new TagsCollection("testHost")
                }
            };

            Assert.That(dataPoints.Stringify(), Is.EqualTo(sampleDataPoints));
        }
    }
}