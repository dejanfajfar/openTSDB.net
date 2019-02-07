using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace OpenTsdbNet.models
{
    public static class DataPointExtensions
    {
        public static string AsString<T>(this DataPoint<T> dataPoint)
        {
            return Serialize(dataPoint);
        }

        public static string AsString<T>(this IEnumerable<DataPoint<T>> singleDataPoints)
        {
            return Serialize(singleDataPoints);
        }

        public static byte[] AsByteArray<T>(this DataPoint<T> dataPoint)
        {
            return Encoding.UTF8.GetBytes(Serialize(dataPoint));
        }

        public static byte[] AsByteArray<T>(this IEnumerable<DataPoint<T>> singleDataPoints)
        {
            return Encoding.UTF8.GetBytes(Serialize(singleDataPoints));
        }

        private static string Serialize<T>(T value)
        {
            var settings = new DataContractJsonSerializerSettings
            {
                EmitTypeInformation = EmitTypeInformation.Never,
                UseSimpleDictionaryFormat = true
            };

            var searializer = new DataContractJsonSerializer(value.GetType(), settings);

            using (var memoryStream = new MemoryStream())
            {
                searializer.WriteObject(memoryStream, value);
                memoryStream.Position = 0;
                var streamreader = new StreamReader(memoryStream);
                return streamreader.ReadToEnd();
            }
        }
    }
}