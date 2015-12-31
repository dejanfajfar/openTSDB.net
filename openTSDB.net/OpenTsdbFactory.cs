using System;

namespace openTsdbNet
{
    public class OpenTsdbFactory
    {
        protected Uri OpenTsdbServerUri { get; }

        public OpenTsdbFactory(Uri openTsdbServerUri)
        {
            OpenTsdbServerUri = openTsdbServerUri;
        }

        public IOpenTsdbManager TsdbManager => new OpenTsdbManager(OpenTsdbServerUri);
    }
}