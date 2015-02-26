
namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Describes the actual file contents for a given Contentful <see cref="Asset"/>
    /// </summary>
    public class File : ContentfulItemBase
    {
        /// <summary>
        /// The original name of the file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// The content type of the data contained within this file
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// An absolute URL to this file
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Any other information stored by Contentful
        /// </summary>
        public dynamic Details { get; set; }
    }
}
