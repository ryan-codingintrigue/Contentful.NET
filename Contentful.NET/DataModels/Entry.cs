using System;
using Newtonsoft.Json.Linq;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a Contentful Entry
    /// </summary>
    public class Entry : ContentfulItemBase, IContentfulItem
    {
        /// <summary>
        /// A dynamic representation of the entire Entry JSON object. Use this to access any
        /// properties which can't be accessed by the friendly Get(T) helpers
        /// </summary>
        public dynamic Fields { get; set; }

        private JObject _jObject;

        private static readonly object Lock = new object();

        /// <summary>
        /// Get a value from the Fields object
        /// </summary>
        /// <typeparam name="T">The C# type to cast the property value to</typeparam>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>A new instance of class T, populated with the JSON data</returns>
        public T GetType<T>(string propertyName)
        {
            return CastPropertyValue<T>(propertyName);
        }

        /// <summary>
        /// Gets a string value from the given Entry property
        /// </summary>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>The value of the property as a String</returns>
        public string GetString(string propertyName)
        {
            return CastPropertyValue<string>(propertyName);
        }

        /// <summary>
        /// Gets a boolean value from the given Entry property
        /// </summary>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>The value of the property as a Boolean</returns>
        public bool? GetBoolean(string propertyName)
        {
            return CastPropertyValue<bool?>(propertyName);
        }

        /// <summary>
        /// Gets a DateTime value from the given Entry property
        /// </summary>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>The value of the property as a DateTime</returns>
        public DateTime? GetDateTime(string propertyName)
        {
            return CastPropertyValue<DateTime?>(propertyName);
        }

        /// <summary>
        /// Gets a string array from the given Entry property
        /// </summary>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>The value of the property as a string array</returns>
        public string[] GetArray(string propertyName)
        {
            return CastPropertyValue<string[]>(propertyName);
        }

        /// <summary>
        /// Gets the details for a linked <see cref="Asset"/> or <see cref="Entry"/>
        /// </summary>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>A new instance of the Link data class</returns>
        public Link GetLink(string propertyName)
        {
            return CastPropertyValue<Link>(propertyName);
        }

        /// <summary>
        /// Gets the details for a single <see cref="Location"/>
        /// </summary>
        /// <param name="propertyName">The name of the property to read from</param>
        /// <returns>A new instance of the Location data class</returns>
        public Location GetLocation(string propertyName)
        {
            return CastPropertyValue<Location>(propertyName);
        }

        // Helper method to cast the value of a property on the JSON object
        // to type T
        private T CastPropertyValue<T>(string propertyName)
        {
            return GetJObject()[propertyName].ToObject<T>();
        }

        // Lazy implementation of the fields JObject. Only deserialized on first usage
        private JObject GetJObject()
        {
            if (_jObject != null) return _jObject;
            lock (Lock)
            {
                _jObject = JObject.FromObject(Fields);
            }
            return _jObject;
        }
    }
}
