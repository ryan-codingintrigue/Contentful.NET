namespace Contentful.NET.Search
{
    internal sealed class SearchFilterComparer
    {
        private readonly string _value;

        internal static readonly SearchFilterComparer Equal = new SearchFilterComparer("=");
        internal static readonly SearchFilterComparer NotEqual = new SearchFilterComparer("\\[ne\\]=");
        internal static readonly SearchFilterComparer In = new SearchFilterComparer("\\[in\\]=");
        internal static readonly SearchFilterComparer NotIn = new SearchFilterComparer("\\[nin\\]=");
        internal static readonly SearchFilterComparer LessThan = new SearchFilterComparer("\\[lt\\]=");
        internal static readonly SearchFilterComparer LessThanEqual = new SearchFilterComparer("\\[lte\\]=");
        internal static readonly SearchFilterComparer GreaterThan = new SearchFilterComparer("\\[gt\\]=");
        internal static readonly SearchFilterComparer GreaterThanEqual = new SearchFilterComparer("\\[gte\\]=");
        internal static readonly SearchFilterComparer LocationNear = new SearchFilterComparer("[near]=");
        internal static readonly SearchFilterComparer LocationWithin = new SearchFilterComparer("[within]=");
        internal static readonly SearchFilterComparer FullText = new SearchFilterComparer("\\[match\\]=");

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
