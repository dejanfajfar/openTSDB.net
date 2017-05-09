using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using openTSDB.net.Exceptions;
using openTSDB.net.Models;

namespace openTSDB.net.Network
{
    public class OpenTsdbIntegration
    {
        public const string API_PUSH = "api/put";

        public OpenTsdbIntegration(Uri openTsdbApiEndpoint)
        {
            OpenTsdbApiEndpoint = openTsdbApiEndpoint;
        }
        
        public Uri OpenTsdbApiEndpoint { get; }

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