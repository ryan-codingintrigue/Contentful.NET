using System;
using System.Collections.Generic;
using System.Linq;

namespace Contentful.NET
{
    /// <summary>
    /// Helper class for manipulating Contentful Image URLs
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Gets an absolute URL to a resized image, given an original image URL returned from the API
        /// </summary>
        /// <param name="originalImageUrl">The original URL of the image, as returned from an API request</param>
        /// <param name="width">The target width constraint of the image</param>
        /// <param name="height">The target height constraint of the image</param>
        /// <param name="type">The target type for the image: PNG or JPEG</param>
        /// <param name="jpegCompression">If the type is set to JPG, specifies the level of compression for the JPEG. Values must be between 1 and 100</param>
        /// <returns>An absolute URL for the resized image</returns>
        public static string GetResizedImageUrl(string originalImageUrl, int? width = null, int? height = null,
            ImageType? type = null, byte? jpegCompression = null)
        {
            if (jpegCompression.HasValue && (jpegCompression.Value < 1 || jpegCompression.Value > 100))
                throw new ArgumentException("JPEG Compression must be a value between 1 and 100");
            var baseUri = originalImageUrl;
            var queryParameters = new Dictionary<string, string>();
            if (width.HasValue) queryParameters.Add("w", width.Value.ToString());
            if (height.HasValue) queryParameters.Add("h", height.Value.ToString());
            if (type.HasValue) queryParameters.Add("fm", type.Value == ImageType.Jpg ? "jpg" : "png");
            if (jpegCompression.HasValue) queryParameters.Add("q", jpegCompression.Value.ToString());
            if (queryParameters.Count == 0) return baseUri;
            return baseUri + "?" + string.Join("&", queryParameters.Select(q => q.Key + "=" + q.Value));
        }

        public enum ImageType
        {
            Png,
            Jpg
        }
    }
}
