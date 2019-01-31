using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTsdbNet.models
{
    /// <summary>
    /// Defines a key/value metadata colection used for openTSDB data submission
    /// </summary>
    public class TagsCollection : Dictionary<string, string>
    {
        /// <summary>
        /// Defines the constant data point origin tag name
        /// </summary>
        public const string HOST = "host";

        /// <summary>
        /// Defines the UNKNOWN constant
        /// </summary>
        public const string UNKWNOWN = "unknown";

        public static TagsCollection New()
        {
            return new TagsCollection();
        }

        /// <inheritdoc />
        public TagsCollection()
        {
            Add(HOST, Environment.MachineName);
        }

        public TagsCollection(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentException(ErrorMessages.HOST_NAME_INVALID_ERROR_MESSAGE, nameof(hostName));
            }
            Add(HOST, hostName);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Keys.Aggregate(0, (current, key) => (current * 333) ^ (key != null ? key.GetHashCode() : 0));
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IDictionary<string, string>))
            {
                return false;
            }

            var second = (IDictionary<string, string>) obj;

            foreach (var keyValuePair in this)
            {
                if (!second.ContainsKey(keyValuePair.Key))
                {
                    return false;
                }
                if (second[keyValuePair.Key] != keyValuePair.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}