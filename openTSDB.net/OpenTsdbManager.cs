using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using openTSDB.net.Models;
using openTSDB.net.Network;

namespace openTSDB.net
{
    public class OpenTsdbManager : IOpenTsdbManager
    {
        protected TsdbOptions Options { get; }
        private OpenTsdbIntegration TsdbServer { get; }

        public OpenTsdbManager(TsdbOptions options)
        {
            Options = options;
            TsdbServer = new OpenTsdbIntegration(options.OpenTsdbServerUri);
        }

        public async Task<TsdbSubmissionResponse> Push<T>(SingleDataPoint<T> dataPoint)
        {
            Trace.Write(dataPoint.Stringify());
            return await TsdbServer.PublishDataAsync(dataPoint.Bytify());

        }

        public void Push<T>(IList<SingleDataPoint<T>> dataPoints)
        {
            TsdbServer.PublishDataAsync(dataPoints.Bytify());
        }

        public async Task<TsdbSubmissionResponse> Push<T>(string name, T value)
        {
            return await Push(new SingleDataPoint<T>
            {
                Metric = name,
                Value = value,
                Timestamp = DateTime.Now.ToUnixEpoch(),
                Tags = Options.DefaultTags
            });
        }
    }
}