using System.Collections.Generic;
using openTsdbNet.models;

namespace openTsdbNet
{
    public interface IOpenTsdbManager
    {
        void Push<T>(SingleDataPoint<T> dataPoint);

        void Push<T>(IList<SingleDataPoint<T>> dataPoints);
    }
}