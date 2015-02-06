using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Base class for all Contentful items
    /// </summary>
    public abstract class ContentfulItemBase
    {
        /// <summary>
        /// Representation of the generic system properties returned from Contentful
        /// </summary>
        /// <see cref="https://www.contentful.com/developers/documentation/content-delivery-api/#system-properties"/>
        [JsonProperty("sys")]
        public SystemProperties SystemProperties { get; set; }
    }
}
