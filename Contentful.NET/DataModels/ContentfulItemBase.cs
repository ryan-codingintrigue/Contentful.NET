using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    public abstract class ContentfulItemBase
    {
        [JsonProperty("sys")]
        public SystemProperties SystemProperties { get; set; }
    }
}
