using System;

namespace openTSDB.net.Exceptions
{
    public class OpenTsdbSubmissionException : Exception
    {
        public OpenTsdbSubmissionException(int httpStatus, string responseMessage, Uri openTsdbUri)
        : base($"[{httpStatus}] : {responseMessage} @ {openTsdbUri}")
        {
            HttpStatusCode = httpStatus;
            HttpResponseMessage = responseMessage;
        }
        public int HttpStatusCode { get; set; }

        public string HttpResponseMessage { get; set; }
    }
}