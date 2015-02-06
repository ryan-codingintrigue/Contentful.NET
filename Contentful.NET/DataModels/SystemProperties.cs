using System;
using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of the generic SystemProperties returned by all Contentful items
    /// </summary>
    /// <see cref="https://www.contentful.com/developers/documentation/content-delivery-api/#system-properties"/>
    public class SystemProperties
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// If applicable, the type of Link
        /// </summary>
        public string LinkType { get; set; }
        /// <summary>
        /// The type of this item
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// If applicable a link to the current space
        /// </summary>
        public Link Space { get; set; }
        /// <summary>
        /// If applicable, a link to the current content type
        /// </summary>
        public Link ContentType { get; set; }
        /// <summary>
        /// If applicable, the revision number of the <see cref="Entry"/> or <see cref="Asset"/>
        /// </summary>
        public int? Revision { get; set; }
        /// <summary>
        /// The Date/Time this item was created
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime? CreatedDateTime { get; set; }
        /// <summary>
        /// The Date/Time this item was last updated
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedDateTime { get; set; }
        /// <summary>
        /// The locale for this item
        /// </summary>
        public string Locale { get; set; }
    }
}
