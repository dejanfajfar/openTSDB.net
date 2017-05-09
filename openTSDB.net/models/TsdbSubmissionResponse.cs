using System;

namespace openTSDB.net.Models
{
    public class TsdbSubmissionResponse
    {
        public int ResponseHttpStatusCode { get; set; }
        public Uri OpenTsdbEndpoint { get; set; }
    }
}