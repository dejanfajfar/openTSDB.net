namespace openTSDB.net
{
    /// <summary>
    /// Centralizes all library wide constants
    /// </summary>
    internal sealed class DefaultValues
    {

        /// <summary>
        /// Defines the common Tag names used in the TagCollection
        /// </summary>
        internal sealed class Tags
        {
            /// <summary>
            /// Defines the constant data point origin tag name
            /// </summary>
            public const string HOST = "host";
        }

        /// <summary>
        /// Defines common validation messages
        /// </summary>
        internal sealed class Messages
        {
            public const string HOST_NAME_INVALID_ERROR_MESSAGE = "The host name can not be null or empty";
            public const string TAG_NAME_INVALID = "The TAG name can not be null or empty";
            public const string TAG_VALUE_INVALID = "Then TAG value ca n not be null or empty";
        }

        /// <summary>
        /// Defines the UNKNOWN constant
        /// </summary>
        public const string UNKWNOWN = "unknown";
    }
}