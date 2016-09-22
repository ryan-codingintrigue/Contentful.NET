namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Describes the details for a given Contentful <see cref="Asset"/>
    /// </summary>
    public class AssetDetails
    {
        /// <summary>
        /// The title for the asset
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A short description for the asset
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The file details for the given asset
        /// </summary>
        public File File { get; set; }
    }
}
