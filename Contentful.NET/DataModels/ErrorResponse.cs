using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of an error returned from the Contentful API
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The generic system properties
        /// </summary>
        [JsonProperty("sys")]
        public SystemProperties SystemProperties { get; set; }
        /// <summary>
        /// The error response message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The unique ID for this request
        /// </summary>
        public string RequestId { get; set; }
    }
}
