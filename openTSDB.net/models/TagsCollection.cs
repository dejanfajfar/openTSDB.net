using System;
using System.Collections.Generic;

namespace openTSDB.net.Models
{
    /// <summary>
    /// Defines a key/value metadata colection used for openTSDB data submission
    /// </summary>
    public class TagsCollection : Dictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagsCollection"/>
        /// with the host set to UNKNOWN
        /// </summary>
        /// <remarks>
        /// A Tag collection must contain at least one key value pair and that is the HOST name
        /// This constructor sets the host name to UNKNOWN
        /// </remarks>
        public TagsCollection() : this(DefaultValues.UNKWNOWN) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="TagsCollection"/>
        /// with the provided host name
        /// </summary>
        /// <param name="hostName">The host name to set for this tags collection</param>
        /// <exception cref="ArgumentException">
        /// If the host name is null or containing only whitespaces
        /// </exception>
        public TagsCollection(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentException(DefaultValues.Messages.HOST_NAME_INVALID_ERROR_MESSAGE, nameof(hostName));
            }
            Add(DefaultValues.Tags.HOST, hostName);
        }
    }
}