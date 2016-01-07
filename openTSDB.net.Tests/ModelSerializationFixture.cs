using System;
using NUnit.Framework;
using openTsdbNet.models;

namespace openTsdbNet.Tests
{
    [TestFixture]
    public class ModelSerializationFixture
    {
        protected ModelSerializer Serializer { get; set; }

        [SetUp]
        public void SetUp()
        {
            Serializer = new ModelSerializer();
        }

        [Test]
        public void SingleDataPoint_JSON_Serialization_OK()
        {
            var serializedDataPoint = Serializer.Stringify(CreateTestDataPoint(15));

            Assert.That(serializedDataPoint, Is.Not.Empty);
            Assert.That(serializedDataPoint, Is.EqualTo("{\"metric\":\"testMetric\",\"timestamp\":1449874800,\"value\":15,\"tags\":{\"host\":\"testHost\"}}"));
        }

        [Test]
        public void SingleDataPointArray_JSON_Serialization_OK()
        {
            var serializedDataPoint = Serializer.Stringify(new [] { CreateTestDataPoint(15), CreateTestDataPoint(14) });

            Assert.That(serializedDataPoint, Is.Not.Empty);
            Assert.That(serializedDataPoint, Is.EqualTo("[{\"metric\":\"testMetric\",\"timestamp\":1449874800,\"value\":15,\"tags\":{\"host\":\"testHost\"}},{\"metric\":\"testMetric\",\"timestamp\":1449874800,\"value\":14,\"tags\":{\"host\":\"testHost\"}}]"));
        }



        private SingleDataPoint<T> CreateTestDataPoint<T>(T value)
        {
            return new SingleDataPoint<T>
            {
                Value = value,
                Metric = "testMetric",
                Timestamp = new DateTime(2015, 12, 12).ToUnixEpoch(),
                Tags =
                {
                    {"host", "testHost"}
                }
            };
        } 
    }
}