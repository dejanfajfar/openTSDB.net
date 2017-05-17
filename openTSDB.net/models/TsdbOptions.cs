using System;

namespace openTSDB.net.Models
{
    /// <summary>
    /// Represents the initial OpenTsdbManager parameters
    /// </summary>
    public class TsdbOptions
    {
        /// <summary>
        /// The URI to the open TSDB server
        /// </summary>
        /// <example>
        /// http://{openTsdbIp}:4242
        /// </example>
        public Uri OpenTsdbServerUri { get; set; }

        /// <summary>
        /// A collection of Tags that will be included in every OpenTSDB data push
        /// </summary>
        public TagsCollection DefaultTags { get; set; } = new TagsCollection();
    }
}