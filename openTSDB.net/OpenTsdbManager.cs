using System;
using System.Collections.Generic;
using openTsdbNet.models;

namespace openTsdbNet
{
    public class OpenTsdbManager : IOpenTsdbManager
    {
        protected Uri OpenTsdbServiceUri { get; private set; }

        public OpenTsdbManager(Uri openTsdbServiceUri)
        {
            OpenTsdbServiceUri = openTsdbServiceUri;
        }

        public void Push<T>(SingleDataPoint<T> dataPoint)
        {
            throw new System.NotImplementedException();
        }

        public void Push<T>(IList<SingleDataPoint<T>> dataPoints)
        {
            throw new System.NotImplementedException();
        }
    }
}