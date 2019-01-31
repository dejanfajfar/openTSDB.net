using System;

namespace OpenTsdbNet.Exceptions
{
    /// <summary>
    /// Thrown when a data point submission to the openTSDB server fails
    /// </summary>
    public class OpenTsdbSubmissionException : Exception
    {
        public OpenTsdbSubmissionException(int httpStatus, string responseMessage, Uri openTsdbUri)
        : base($"[{httpStatus}] : {responseMessage} @ {openTsdbUri}")
        {
            HttpStatusCode = httpStatus;
            HttpResponseMessage = responseMessage;
            OpenTsdbUri = openTsdbUri;
        }

        /// <summary>
        /// Gets the URI of the openTSDB servr used
        /// </summary>
        public Uri OpenTsdbUri { get; }

        /// <summary>
        /// Gets the HTTP status code returned while submitting the data point
        /// </summary>
        public int HttpStatusCode { get; }

        /// <summary>
        /// Gets the response message or explanation of the error that happened while submitting the data point
        /// </summary>
        public string HttpResponseMessage { get; }
    }
}