using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using openTSDB.net.Models;

namespace openTSDB.net
{
    public static class DataPointExtentions
    {
        public static string Stringify<T>(this DataPoint<T> dataPoint)
        {
            return Serialize(dataPoint);
        }

        public static string Stringify<T>(this IEnumerable<DataPoint<T>> singleDataPoints)
        {
            return Serialize(singleDataPoints);
        }

        public static byte[] Bytify<T>(this DataPoint<T> dataPoint)
        {
            return Encoding.UTF8.GetBytes(Serialize(dataPoint));
        }

        public static byte[] Bytify<T>(this IEnumerable<DataPoint<T>> singleDataPoints)
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

            using (var memorySteram = new MemoryStream())
            {
                searializer.WriteObject(memorySteram, value);
                memorySteram.Position = 0;
                var streamreader = new StreamReader(memorySteram);
                return streamreader.ReadToEnd();
            }
        }
    }
}