using System.Threading.Tasks;
using OpenTsdbNet.Exceptions;
using OpenTsdbNet.models;

namespace OpenTsdbNet.Network
{
    /// <summary>
    /// Defines the openTSDB network bridge interface
    /// </summary>
    public interface IOpenTsdbNetworkBridge
    {
        /// <summary>
        /// Publishes a single data point to the openTSDB server
        /// </summary>
        /// <param name="data">The data point to be published</param>
        /// <returns>The data point submission result</returns>
        /// <exception cref="OpenTsdbSubmissionException">
        /// If a error occures durring data submission or if the openTsdb return code os not 204
        /// </exception>
        Task<TsdbSubmissionResponse> PublishDataAsync(byte[] data);
    }
}