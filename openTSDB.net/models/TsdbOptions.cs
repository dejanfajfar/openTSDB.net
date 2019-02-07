using System;

namespace OpenTsdbNet.models
{
    /// <summary>
    /// Represents the initial OpenTsdbManager parameters
    /// </summary>
    public class TsdbOptions
    {
        public static TsdbOptions New(string serverEndpoint)
        {
            return new TsdbOptions
            {
                ServerUri = new Uri(serverEndpoint)
            };
        } 
        
        public TsdbOptions()
        {
            DefaultTags = TagsCollection.New();
        }

        /// <summary>
        /// The URI to the open TSDB server
        /// </summary>
        /// <example>
        /// http://{openTsdbIp}:4242
        /// </example>
        public Uri ServerUri { get; set; }

        /// <summary>
        /// A collection of Tags that will be included in every OpenTSDB data push
        /// </summary>
        public TagsCollection DefaultTags { get; }
    }
}