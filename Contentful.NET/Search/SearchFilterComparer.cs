namespace Contentful.NET.Search
{
    /// <summary>
    /// Type-safe-enum pattern which allows for mapping a string comparer value to a C# enum-style object
    /// for ease of use in IntelliSense
    /// </summary>
    public sealed class SearchFilterComparer
    {
        private readonly string _value;

        public static readonly SearchFilterComparer Equal = new SearchFilterComparer("=");
        public static readonly SearchFilterComparer NotEqual = new SearchFilterComparer("\\[ne\\]=");
        public static readonly SearchFilterComparer In = new SearchFilterComparer("\\[in\\]=");
        public static readonly SearchFilterComparer NotIn = new SearchFilterComparer("\\[nin\\]=");
        public static readonly SearchFilterComparer LessThan = new SearchFilterComparer("\\[lt\\]=");
        public static readonly SearchFilterComparer LessThanEqual = new SearchFilterComparer("\\[lte\\]=");
        public static readonly SearchFilterComparer GreaterThan = new SearchFilterComparer("\\[gt\\]=");
        public static readonly SearchFilterComparer GreaterThanEqual = new SearchFilterComparer("\\[gte\\]=");
        public static readonly SearchFilterComparer LocationNear = new SearchFilterComparer("[near]=");
        public static readonly SearchFilterComparer LocationWithin = new SearchFilterComparer("[within]=");
        public static readonly SearchFilterComparer FullText = new SearchFilterComparer("\\[match\\]=");

        private SearchFilterComparer(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
