using System.Collections.Generic;
using System.Threading.Tasks;
using openTSDB.net.Models;

namespace openTSDB.net
{
    /// <summary>
    /// Defines the openTSDB management interface
    /// </summary>
    public interface IOpenTsdbManager
    {
        /// <summary>
        /// Pushes a single data point to the openTSDB
        /// </summary>
        /// <param name="dataPoint">The data point to be submitted to the openTSDB</param>
        /// <typeparam name="T">The underlying data point type</typeparam>
        /// <returns>A openTSDB data submission response</returns>
        Task<TsdbSubmissionResponse> PushAsync<T>(DataPoint<T> dataPoint);

        /// <summary>
        /// Submitst multiple data points at the same time
        /// </summary>
        /// <param name="dataPoints">The array of list of data points to be submitted</param>
        /// <typeparam name="T">The underlying type of the data point</typeparam>
        /// <returns>A openTSDB data submission response</returns>
        Task<TsdbSubmissionResponse> PushAsync<T>(IList<DataPoint<T>> dataPoints);

        /// <summary>
        /// Shorthand function to quickly submit a single data point
        /// </summary>
        /// <param name="name">The name of the data point</param>
        /// <param name="value">The value of the data point</param>
        /// <typeparam name="T">The underlying data point value</typeparam>
        /// <returns>A openTSDB data submission response</returns>
        Task<TsdbSubmissionResponse> PushAsync<T>(string name, T value);
    }
}