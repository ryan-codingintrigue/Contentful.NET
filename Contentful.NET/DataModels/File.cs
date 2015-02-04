
namespace Contentful.NET.DataModels
{
    public class File : ContentfulItemBase
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }
        public dynamic Details { get; set; }
    }
}
