
namespace OpenTsdbNet
{
    /// <summary>
    /// Defines common validation messages
    /// </summary>
    public sealed class ErrorMessages
    {
        public const string HOST_NAME_INVALID_ERROR_MESSAGE = "The host name can not be null or empty";
        public const string TAG_NAME_INVALID = "The TAG name can not be null or empty";
        public const string TAG_VALUE_INVALID = "Then TAG value ca n not be null or empty";
        public const string SERVER_URI_INVALID = "The openTsdb server URI can not be null";
        public const string TAG_COLLECTION_NULL = "The provided tag collection can not be null";
        public const string NAMED_MANAGER_INSTANCE_ALREADY_REGISTERED = "A instance with the same name already exists";
        public const string NAMED_MANAGER_INSTANCE_NAME_INVALID = "The provided manager instance name is invalid";
        public const string MANAGER_OPTIONS_NULL = "The provided TsdbOptions can not be null";
        public const string NETWORK_BRIDGE_NULL = "The provided network bridge can not be null";
        public const string DATA_POINT_NULL = "Trying to submit a null data point which is not possible";
        public const string DATA_POINT_NAME_INVALID = "The provided data point name cannot be null or empty";
    }
}