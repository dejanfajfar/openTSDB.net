using System;
using System.Net;
using openTsdbNet.models;

namespace openTsdbNet.Network
{
    public class OpenTsdbIntegration
    {
        public const string API_PUSH = "api/push";

        public OpenTsdbIntegration(string openTsdbApiEndpoint)
        {
            this.openTsdbApiEndpoint = openTsdbApiEndpoint;
        }
        
        public string openTsdbApiEndpoint { get; }

        public void PublishData<T>(SingleDataPoint<T> dataPoint)
        {
            var endpoint = new Uri(new Uri(openTsdbApiEndpoint), API_PUSH);
            var request = WebRequest.Create(endpoint);
            request.Method = "POST";
            
        }

    }
}