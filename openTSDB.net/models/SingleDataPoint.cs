
using System.Runtime.Serialization;

namespace openTsdbNet.models
{
    [DataContract]
    public class SingleDataPoint<TVal>
    {
        public SingleDataPoint()
        {
            Tags = new TagsCollection();
        } 

        [DataMember(Name = "metric")]
        public string Metric { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        [DataMember(Name = "value")]
        public TVal Value { get; set; }

        [DataMember(Name = "tags", Order = 99)]
        public TagsCollection Tags { get; }
    }
}