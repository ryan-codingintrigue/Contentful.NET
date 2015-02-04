

using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    public class Asset : ContentfulItemBase, IContentfulItem
    {
        [JsonProperty("fields")]
        public AssetDetails Details { get; set; }
    }
}
