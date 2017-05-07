using System;
using openTSDB.net.Models;

namespace openTSDB.net
{
    public class OpenTsdbFactory
    {
        protected Uri OpenTsdbServerUri { get; }

        public OpenTsdbFactory(Uri openTsdbServerUri)
        {
            OpenTsdbServerUri = openTsdbServerUri;
        }

        public OpenTsdbFactory(TsdbFactoryOptions options)
        {

        }

        public IOpenTsdbManager TsdbManager => new OpenTsdbManager(OpenTsdbServerUri);
    }
}