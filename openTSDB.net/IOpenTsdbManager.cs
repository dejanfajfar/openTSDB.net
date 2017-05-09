using System.Collections.Generic;
using System.Threading.Tasks;
using openTSDB.net.Models;

namespace openTSDB.net
{
    public interface IOpenTsdbManager
    {
        Task<TsdbSubmissionResponse> Push<T>(SingleDataPoint<T> dataPoint);

        void Push<T>(IList<SingleDataPoint<T>> dataPoints);

        Task<TsdbSubmissionResponse> Push<T>(string name, T value);
    }
}