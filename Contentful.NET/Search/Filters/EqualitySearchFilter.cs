using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to compare values using strict equality
    /// </summary>
    public sealed class EqualitySearchFilter : ISearchFilter
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
        /// <param name="equality">The equality operator to use for comparison</param>
        /// <exception cref="ArgumentException">Thrown if the provided propertyName is invalid</exception>
        public EqualitySearchFilter(string propertyName, string equalityValue, Equality equality = Equality.Equal)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = (equality == Equality.Equal ? SearchFilterComparer.Equal : SearchFilterComparer.NotEqual).ToString();
            Value = equalityValue;
        }
    }
}
