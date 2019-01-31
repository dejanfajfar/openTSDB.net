using System;

namespace OpenTsdbNet.models
{
    /// <summary>
    /// Represents the initial OpenTsdbManager parameters
    /// </summary>
    public class TsdbOptions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="openTsdbServer">The URI to the openTSDB server</param>
        /// <param name="hostName">The name of the event data origin host</param>
        public TsdbOptions(Uri openTsdbServer, string hostName)
        : this(openTsdbServer, TagsCollection.New())
        {}

        /// <summary>
        ///
        /// </summary>
        /// <param name="openTsdbServer"></param>
        /// <param name="defaultCollection"></param>
        public TsdbOptions(Uri openTsdbServer, TagsCollection defaultCollection)
        {
            OpenTsdbServerUri = openTsdbServer ?? throw new ArgumentException(ErrorMessages.SERVER_URI_INVALID, nameof(openTsdbServer));
            DefaultTags = defaultCollection ?? throw new ArgumentException(ErrorMessages.TAG_COLLECTION_NULL, nameof(defaultCollection));
        }

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
        public TagsCollection DefaultTags { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TsdbOptions))
            {
                return false;
            }

            var second = (TsdbOptions) obj;

            return string.Compare(OpenTsdbServerUri.AbsoluteUri, second.OpenTsdbServerUri.AbsoluteUri, StringComparison.InvariantCulture) == 0
                   && DefaultTags.Equals(second.DefaultTags);
        }

        /// <summary>
        /// Gets the
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 0;

                // String properties
                hashCode = (hashCode * 397) ^ (OpenTsdbServerUri.AbsoluteUri != null ? OpenTsdbServerUri.AbsoluteUri.GetHashCode() : 0);

                hashCode = (hashCode * 397) ^ DefaultTags.GetHashCode();

                return hashCode;
            }
        }
    }
}