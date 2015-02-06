
namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a Contentful Content Type
    /// </summary>
    public class ContentType : ContentfulItemBase, IContentfulItem
    {
        /// <summary>
        /// The name of the content type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A short description for the content type
        /// </summary>
        public string Description { get; set; }
    }
}
