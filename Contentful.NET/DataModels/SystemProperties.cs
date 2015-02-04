using System;

namespace Contentful.NET.DataModels
{
    public class SystemProperties
    {
        public string Id { get; set; }
        public string LinkType { get; set; }
        public Link Space { get; set; }
        public Link ContentType { get; set; }
        public int? Revision { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
