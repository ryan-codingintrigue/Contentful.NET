using System;
using System.Collections.Generic;
using Contentful.NET.DataModels;

namespace Contentful.NET
{
    /// <summary>
    /// Internal class which handles resolving the URLs to the Contentful REST endpoints for 
    /// each individual ContentItem type
    /// </summary>
    internal static class RestEndpointResolver
    {
        // Base formatted URL to the Contentful CDN
        private const string ContentfulApiBase = "https://cdn.contentful.com/spaces/{0}";

        // Hardcoded mapping of IContentItems which have a corresponding endpoint URL
        private static readonly Dictionary<Type, string> EndpointDictionary = new Dictionary<Type, string>
        {
            { typeof(Asset), "/assets/"},
            { typeof(ContentType), "/content_types/"},
            { typeof(Entry), "/entries/"},
            { typeof(Space), ""}
        };

        /// <summary>
        /// Gets the endpoint for a given IContentfulItem type
        /// </summary>
        /// <typeparam name="T">The type of request being made</typeparam>
        /// <param name="space">The ID of the Space used to generate the endpoint URL</param>
        /// <returns>A generated URL to the REST Endpoint represented by T</returns>
        internal static string GetEndpointUrl<T>(string space) where T : IContentfulItem
        {
            return string.Format(ContentfulApiBase + EndpointDictionary[typeof (T)], space);
        }
    }
}
