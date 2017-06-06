using System;

namespace openTSDB.net.Models
{
    /// <summary>
    /// Data submission response
    /// </summary>
    public class TsdbSubmissionResponse
    {
        /// <summary>
        /// The HTTP response code given by the openTSDB server
        /// </summary>
        public int ResponseHttpStatusCode { get; set; }

        /// <summary>
        /// The Endpoint used to submit the data
        /// </summary>
        public Uri OpenTsdbEndpoint { get; set; }
    }
}