using openTSDB.net.Models;

namespace openTSDB.net
{
    public static class OpenTsdbFactory
    {
        private static IOpenTsdbManager instance;

        public static IOpenTsdbManager TsdbManager(TsdbOptions options) => new OpenTsdbManager(options);

        public static IOpenTsdbManager TsdbManagerSingelton(TsdbOptions options)
        {
            return instance ?? (instance = TsdbManager(options));
        }
    }
}