
namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a locale property
    /// </summary>
    public class Locale
    {
        /// <summary>
        /// The friendly-name for the locale
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The code for the locale, in the format 'en-US'
        /// </summary>
        public string Code { get; set; }
    }
}
