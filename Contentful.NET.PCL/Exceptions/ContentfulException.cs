using System;
using Contentful.NET.DataModels;
using Newtonsoft.Json;

namespace Contentful.NET.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a call to the Contentful API fails
    /// </summary>
    public class ContentfulException : Exception
    {
        /// <summary>
        /// The HTTP Response code returned from Contentful
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// The details of the error returned from the Contentful service
        /// </summary>
        public ErrorResponse ErrorDetails { get; set; }

        /// <summary>
        /// Constructs a new instance of a ContentfulException with the given HTTP error code and error details
        /// </summary>
        /// <param name="errorCode">The integer value of the HTTP Response code</param>
        /// <param name="jsonResponse">A JSON representation of the error thrown by the Contentful API</param>
        public ContentfulException(int errorCode, string jsonResponse)
        {
            ErrorCode = errorCode;
            ErrorDetails = JsonConvert.DeserializeObject<ErrorResponse>(jsonResponse);
        }
    }
}
