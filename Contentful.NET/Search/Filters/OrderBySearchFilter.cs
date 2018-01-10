using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to sort returned content
    /// </summary>
    public class OrderBySearchFilter : ISearchFilter
    {
        /// <summary>
        /// Always set to 'order' for this filter
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// Always set to '=' for this filter
        /// </summary>
        public string Comparison { get; private set; }

        /// <summary>
        /// The name of the property to sort on
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new filter instance with the given property and order by direction
        /// </summary>
        /// <param name="propertyName">The name of the Content property to sort on</param>
        /// <param name="direction">The direction in which to sort the results</param>
        /// <exception cref="System.ArgumentException">Thrown if the provided propertyName is invalid</exception>
        public OrderBySearchFilter(string propertyName, OrderByDirection direction)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = "order";
            Comparison = direction == OrderByDirection.Ascending ? "=" : "=-";
            Value = propertyName;
        }
    }
}
