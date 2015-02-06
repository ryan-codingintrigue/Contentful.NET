using System.Collections.Generic;
using Newtonsoft.Json;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a number of included <see cref="Asset"/>s or <see cref="Entry"/> objects
    /// </summary>
    public class Includes
    {
        /// <summary>
        /// An enumerable of linked Assets
        /// </summary>
        [JsonProperty("Asset")]
        public IEnumerable<Asset> Assets { get; set; }
        /// <summary>
        /// An enumerable of linked Entries
        /// </summary>
        [JsonProperty("Entry")]
        public IEnumerable<Entry> Entries { get; set; }
    }
}
