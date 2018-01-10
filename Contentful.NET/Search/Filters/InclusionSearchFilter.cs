using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to search through arrays or lists for a given value
    /// </summary>
    public sealed class InclusionSearchFilter : ISearchFilter
    {
        /// <summary>
        /// The name of the property to compare to
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// The value of the equality comparison to use
        /// </summary>
        public string Comparison { get; private set; }

        /// <summary>
        /// The value to test equality against
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new filter instance with the given property and equality criteria
        /// </summary>
        /// <param name="propertyName">The name of the Content property to test against</param>
        /// <param name="equalityValue">The String value to compare against</param>
        /// <param name="equality">The equality operator to use for comparison - defaults to In</param>
        /// <exception cref="System.ArgumentException">Thrown if the provided propertyName is invalid</exception>
        public InclusionSearchFilter(string propertyName, string equalityValue, InEquality equality = InEquality.In)
        {
            if(string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = (equality == InEquality.In ? SearchFilterComparer.In : SearchFilterComparer.NotIn).ToString();
            Value = equalityValue;
        }
    }
}
