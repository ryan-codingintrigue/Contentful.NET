﻿using System;
using System.Globalization;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to compare numeric values
    /// </summary>
    public sealed class NumericSearchFilter : ISearchFilter
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
        /// <param name="equalityValue">The decimal value to compare against</param>
        /// <param name="equality">The equality operator to use for comparison</param>
        /// <exception cref="System.ArgumentException">Thrown if the provided propertyName is invalid</exception>
        public NumericSearchFilter(string propertyName, decimal equalityValue, NumericEquality equality)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            switch (equality)
            {
                    case NumericEquality.LessThan:
                    Comparison = SearchFilterComparer.LessThan.ToString(); break;
                    case NumericEquality.LessThanEqualTo:
                        Comparison = SearchFilterComparer.LessThanEqual.ToString(); break;
                    case NumericEquality.GreaterThan:
                        Comparison = SearchFilterComparer.GreaterThan.ToString(); break;
                    case NumericEquality.GreaterThanEqualTo:
                        Comparison = SearchFilterComparer.GreaterThanEqual.ToString(); break;
            }
            Value = equalityValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}
