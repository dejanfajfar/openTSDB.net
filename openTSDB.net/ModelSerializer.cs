using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using openTsdbNet.models;

namespace openTsdbNet
{
    public class ModelSerializer
    {
        public string Stringify<T>(SingleDataPoint<T> singleDataPoint)
        {
            return Serialize(singleDataPoint);
        }

        public string Stringify<T>(IEnumerable<SingleDataPoint<T>> singleDataPoints)
        {
            return Serialize(singleDataPoints);
        }

        private string Serialize<T>(T value)
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