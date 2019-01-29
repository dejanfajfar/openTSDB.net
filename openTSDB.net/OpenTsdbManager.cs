using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epoch.net;
using openTSDB.net.Models;
using openTSDB.net.Network;

namespace openTSDB.net
{
    public class OpenTsdbManager : IOpenTsdbManager
    {
        protected TsdbOptions Options { get; }
        private IOpenTsdbNetworkBridge TsdbServer { get; }

        public OpenTsdbManager(TsdbOptions options, IOpenTsdbNetworkBridge server)
        {
            Options = options ?? throw new ArgumentNullException(ErrorMessages.MANAGER_OPTIONS_NULL, nameof(options));
            TsdbServer = server ?? throw new ArgumentNullException(ErrorMessages.NETWORK_BRIDGE_NULL, nameof(server));
        }

        public async Task<TsdbSubmissionResponse> PushAsync<T>(DataPoint<T> dataPoint)
        {
            if (dataPoint == null)
            {
                throw new ArgumentNullException(ErrorMessages.DATA_POINT_NULL, nameof(dataPoint));
            }
            return await TsdbServer.PublishDataAsync(dataPoint.Bytify());

        }

        public async Task<TsdbSubmissionResponse> PushAsync<T>(IList<DataPoint<T>> dataPoints)
        {
            if (dataPoints == null)
            {
                throw new ArgumentNullException(ErrorMessages.DATA_POINT_NULL, nameof(dataPoints));
            }
            return await TsdbServer.PublishDataAsync(dataPoints.Bytify());
        }

        public async Task<TsdbSubmissionResponse> PushAsync<T>(string name, T value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ErrorMessages.DATA_POINT_NAME_INVALID, nameof(name));
            }
            return await PushAsync(new DataPoint<T>
            {
                Metric = name,
                Value = value,
                Timestamp = DateTime.Now.ToRawEpoch(),
                Tags = Options.DefaultTags
            });
        }
    }
}