using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Epoch.net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openTSDB.net;
using openTSDB.net.Models;

namespace OpenTsdb.Net.Test.DataPointFixtures
{
    [TestClass]
    public class ByteSerializationsFixture
    {
        [TestMethod]
        [DeploymentItem("DataPointFixtures/DataPointSample.json")]
        public void SerializeDataPoint()
        {
            var sampleDataPoint = File.ReadAllText("DataPointFixtures/DataPointSample.json", Encoding.UTF8);

            var dataPoint = new DataPoint<int>
            {
                Value = 15,
                Metric = "testMetric",
                Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch(),
                Tags = new TagsCollection("testHost")
            };

            CollectionAssert.AreEqual(dataPoint.Bytify(), Encoding.UTF8.GetBytes(sampleDataPoint));
        }

        [TestMethod]
        [DeploymentItem(@"DataPointFixtures/DataPointListSample.json")]
        public void SerializeDataPointList()
        {
            var sampleDataPoints = File.ReadAllText(@"DataPointFixtures/DataPointListSample.json");

            var dataPoints = new[]
            {
                new DataPoint<int>
                {
                    Value = 15,
                    Metric = "testMetric",
                    Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch(),
                    Tags = new TagsCollection("testHost")
                },
                new DataPoint<int>
                {
                    Value = 14,
                    Metric = "testMetric",
                    Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch(),
                    Tags = new TagsCollection("testHost")
                }
            };

            CollectionAssert.AreEqual(dataPoints.Bytify(), Encoding.UTF8.GetBytes(sampleDataPoints));
        }
    }
}