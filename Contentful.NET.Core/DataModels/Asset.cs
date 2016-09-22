

using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Describes a Contentful Asset
    /// </summary>
    /// <see cref="https://www.contentful.com/developers/documentation/content-delivery-api/#assets"/>
    public class Asset : ContentfulItemBase, IContentfulItem
    {
        /// <summary>
        /// The details object for the given asset
        /// </summary>
        [JsonProperty("fields")]
        public AssetDetails Details { get; set; }
    }
}
