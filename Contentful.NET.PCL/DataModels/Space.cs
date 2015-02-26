namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a Contentful "Space"
    /// </summary>
    public class Space : ContentfulItemBase, IContentfulItem
    {
        /// <summary>
        /// The friendly name for the space
        /// </summary>
        public string Name { get; set; }
    }
}