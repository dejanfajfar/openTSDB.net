using openTSDB.net.Models;

namespace openTSDB.net
{
    public static class OpenTsdbFactory
    {
        private static IOpenTsdbManager instance;

        public static IOpenTsdbManager CreateNew(TsdbOptions options) => new OpenTsdbManager(options);

        public static IOpenTsdbManager GetExisting(TsdbOptions options)
        {
            if (instance == null)
            {
                instance = new OpenTsdbManager(options);
            }

            return instance;
        }

        public static IOpenTsdbManager CreateNamed(string name, TsdbOptions options) => new OpenTsdbManager(options);

        public static IOpenTsdbManager GetNamed(string Name)
        {
            return instance;
        }
    }
}