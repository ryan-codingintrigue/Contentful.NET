namespace Contentful.NET.Search
{
    /// <summary>
    /// Contract which describes a key/value pair to be sent to the Contentful API REST URL
    /// </summary>
    public interface ISearchFilter
    {
        /// <summary>
        /// The QueryString "key" for this filter
        /// </summary>
        string Field { get; }
        /// <summary>
        /// The equality comparator for this filter
        /// </summary>
        string Comparison { get; }
        /// <summary>
        /// The QueryString "value" for this filter
        /// </summary>
        string Value { get; }
    }
}
