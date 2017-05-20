using System;
using System.IO;
using System.Text;
using Epoch.net;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.DataPointFixtures
{
    [TestFixture]
    public class ByteSerilizationFixture
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

            Assert.That(dataPoint.Bytify(), Is.EqualTo(Encoding.UTF8.GetBytes(sampleDataPoint)));
        }

        [Test]
        public void SerializeDataPointList()
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

            Assert.That(dataPoints.Bytify(), Is.EqualTo(Encoding.UTF8.GetBytes(sampleDataPoints)));
        }
    }
}