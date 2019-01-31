using System.Runtime.Serialization;

namespace OpenTsdbNet.models
{
    /// <summary>
    /// Defines a single data point that can be submitted to the openTSDB server
    /// </summary>
    /// <typeparam name="TVal"></typeparam>
    [DataContract]
    public class DataPoint<TVal>
    {
        /// <summary>
        /// Gets or sets the metrics name to be used
        /// </summary>
        /// <example>app.login.count</example>
        [DataMember(Name = "metric")]
        public string Metric { get; set; }

        /// <summary>
        /// The timestamp of the data event in unix Epoch format
        /// </summary>
        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        /// <summary>
        /// The value of the data point
        /// </summary>
        /// <remarks>
        /// According to the documentation at http://opentsdb.net/docs/build/html/api_http/put.html
        /// the value can be an integer, float or string
        /// </remarks>
        [DataMember(Name = "value")]
        public TVal Value { get; set; }

        /// <summary>
        /// A key/value metadata list.
        /// </summary>
        [DataMember(Name = "tags", Order = 99)]
        public TagsCollection Tags { get; set; } = new TagsCollection();
    }
}