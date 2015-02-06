using System;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to search location-based fields
    /// </summary>
    public sealed class LocationSearchFilter : ISearchFilter
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
        /// Creates a new Location search to find any content NEAR the given latitude/longitude
        /// </summary>
        /// <param name="propertyName">The name of the location property to search</param>
        /// <param name="latitude">The central latitude point to search from</param>
        /// <param name="longitude">The central longitude point to search from</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the latitude/longitude does not fall within the expected values</exception>
        /// <exception cref="ArgumentException">Thrown if the propertyName is not provided</exception>
        public LocationSearchFilter(string propertyName, decimal latitude, decimal longitude)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException("latitude", latitude,
                    "Latitude was not within the expected range [-90 - +90]");
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException("longitude", longitude,
                    "Longitude was not within the expected range [-180 - +180]");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = SearchFilterComparer.LocationNear.ToString();
            Value = string.Join(",", new[] { latitude, longitude });
        }

        /// <summary>
        /// Creates a new Location search to find any content WITHIN a radius of a given latitude/longitude
        /// </summary>
        /// <param name="propertyName">The name of the location property to search</param>
        /// <param name="latitude">The central latitude point to search from</param>
        /// <param name="longitude">The central longitude point to search from</param>
        /// <param name="radius">The size of the radius (in kilometers) to search around</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the latitude/longitude does not fall within the expected values</exception>
        /// <exception cref="ArgumentException">Thrown if the propertyName is not provided</exception>
        public LocationSearchFilter(string propertyName, decimal latitude, decimal longitude, decimal radius)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException("latitude", latitude,
                    "Latitude was not within the expected range [-90 - +90]");
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException("longitude", longitude,
                    "Longitude was not within the expected range [-180 - +180]");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = SearchFilterComparer.LocationWithin.ToString();
            Value = string.Join(",", new[] { latitude, longitude, radius });
        }

        /// <summary>
        /// Creates a new Location search to find any content WITHIN a given latitude/longitude rectangle
        /// </summary>
        /// <param name="propertyName">The name of the location property to search</param>
        /// <param name="latitude">The latitude of the bottom left corner of the rectangle</param>
        /// <param name="longitude">The longitude of the bottom left corner of the rectangle</param>
        /// <param name="latitude2">The latitude of the top right corner of the rectangle</param>
        /// <param name="longitude2">The longitude of the top right corner of the rectangle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the latitude/longitude does not fall within the expected values</exception>
        /// <exception cref="ArgumentException">Thrown if the propertyName is not provided</exception>
        public LocationSearchFilter(string propertyName, decimal latitude, decimal longitude, decimal latitude2, decimal longitude2)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException("latitude", latitude,
                    "Latitude was not within the expected range [-90 - +90]");
            if (latitude2 < -90 || latitude2 > 90)
                throw new ArgumentOutOfRangeException("latitude2", latitude2,
                    "Latitude2 was not within the expected range [-90 - +90]");
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException("longitude", longitude,
                    "Longitude was not within the expected range [-180 - +180]");
            if (longitude2 < -180 || longitude2 > 180)
                throw new ArgumentOutOfRangeException("longitude2", longitude2,
                    "Longitude2 was not within the expected range [-180 - +180]");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = SearchFilterComparer.LocationWithin.ToString();
            Value = string.Join(",", new[] { latitude, longitude, latitude2, longitude2 });
        }
    }
}
