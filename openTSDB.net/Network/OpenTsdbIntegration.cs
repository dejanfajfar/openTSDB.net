using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using openTSDB.net.Exceptions;
using openTSDB.net.Models;

namespace openTSDB.net.Network
{
    /// <summary>
    /// Network integration layer
    /// </summary>
    internal class OpenTsdbIntegration : IOpenTsdbNetworkBridge
    {
        /// <summary>
        /// The relative path to the put endpoint
        /// </summary>
        public const string API_PUSH = "api/put";

        /// <summary>
        /// Initializes a new <see cref="OpenTsdbIntegration"/> with the given endpoint
        /// </summary>
        /// <param name="openTsdbApiEndpoint">THe endpoint of the openTSDB server</param>
        public OpenTsdbIntegration(Uri openTsdbApiEndpoint)
        {
            OpenTsdbApiEndpoint = openTsdbApiEndpoint;
        }

        /// <summary>
        /// Gets the endpoint tot he openTSDB server
        /// </summary>
        public Uri OpenTsdbApiEndpoint { get; }

        /// <summary>
        /// Publishes a single data point to the openTSDB server
        /// </summary>
        /// <param name="data">The data point to be published</param>
        /// <returns>The data point submission result</returns>
        /// <exception cref="OpenTsdbSubmissionException">
        /// If a error occures durring data submission or if the openTsdb return code os not 204
        /// </exception>
        public async Task<TsdbSubmissionResponse> PublishDataAsync(byte[] data)
        {
            var endpoint = new Uri(OpenTsdbApiEndpoint, API_PUSH);

            var client = new HttpClient();
            var response = await client.PostAsync(endpoint, new ByteArrayContent(data));

            // The API should respond with a 204 (NoContent) uppon sucsess
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new OpenTsdbSubmissionException((int) response.StatusCode, response.ReasonPhrase, endpoint);
            }

            return new TsdbSubmissionResponse
            {
                ResponseHttpStatusCode = (int) response.StatusCode,
                OpenTsdbEndpoint = endpoint
            };
        }
    }
}