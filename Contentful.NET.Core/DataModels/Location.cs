using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a location property
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The latitude of the location
        /// </summary>
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
        /// <summary>
        /// The longitude of the location
        /// </summary>
        [JsonProperty("lon")]
        public decimal Longitude { get; set; }
    }
}
