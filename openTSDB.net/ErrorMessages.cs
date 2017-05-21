namespace openTSDB.net
{
    /// <summary>
    /// Defines common validation messages
    /// </summary>
    internal sealed class ErrorMessages
    {
        public const string HOST_NAME_INVALID_ERROR_MESSAGE = "The host name can not be null or empty";
        public const string TAG_NAME_INVALID = "The TAG name can not be null or empty";
        public const string TAG_VALUE_INVALID = "Then TAG value ca n not be null or empty";
        public const string SERVER_URI_INVALID = "The openTsdb server URI can not be null";
        public const string TAG_COLLECTION_NULL = "The provided tag collection can not be null";
    }
}