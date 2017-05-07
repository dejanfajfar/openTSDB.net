using System;
using System.Net;

namespace openTSDB.net.Network
{
    public class OpenTsdbIntegration
    {
        public const string API_PUSH = "api/push";

        public OpenTsdbIntegration(Uri openTsdbApiEndpoint)
        {
            OpenTsdbApiEndpoint = openTsdbApiEndpoint;
        }
        
        public Uri OpenTsdbApiEndpoint { get; }

        public async void PublishDataAsync(byte[] data)
        {
            var endpoint = new Uri(OpenTsdbApiEndpoint, API_PUSH);
            var request = WebRequest.Create(endpoint);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            request.Headers.Add("Acepts", "Application/json");

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            var response = await request.GetResponseAsync() as HttpWebResponse;


        }

    }
}