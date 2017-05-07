using System.Collections.Generic;
using openTSDB.net.Models;

namespace openTSDB.net
{
    public interface IOpenTsdbManager
    {
        void Push<T>(SingleDataPoint<T> dataPoint);

        void Push<T>(IList<SingleDataPoint<T>> dataPoints);

        void Push<T>(string name, T value);
    }
}