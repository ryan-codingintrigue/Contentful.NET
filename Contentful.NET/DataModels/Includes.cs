using System.Collections.Generic;
using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    public class Includes
    {
        [JsonProperty("Asset")]
        public IEnumerable<Asset> Assets { get; set; }
        [JsonProperty("Entry")]
        public IEnumerable<Entry> Entries { get; set; }
    }
}
