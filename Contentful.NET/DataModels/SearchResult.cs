using System.Collections.Generic;

namespace Contentful.NET.DataModels
{
    public class SearchResult<T> where T : IContentfulItem
    {
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
        public IEnumerable<T> Items { get; set; }
        public Includes Includes { get; set; }
    }
}
