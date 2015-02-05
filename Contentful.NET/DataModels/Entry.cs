using System;
using Newtonsoft.Json.Linq;

namespace Contentful.NET.DataModels
{
    public class Entry : ContentfulItemBase, IContentfulItem
    {
        public dynamic Fields { get; set; }

        private JObject _jObject;

        private static readonly object Lock = new object();

        public T GetType<T>(string propertyName)
        {
            return CastPropertyValue<T>(propertyName);
        }

        public string GetString(string propertyName)
        {
            return CastPropertyValue<string>(propertyName);
        }

        public bool GetBoolean(string propertyName)
        {
            return CastPropertyValue<bool>(propertyName);
        }

        public DateTime GetDateTime(string propertyName)
        {
            return CastPropertyValue<DateTime>(propertyName);
        }

        public string[] GetArray(string propertyName)
        {
            return CastPropertyValue<string[]>(propertyName);
        }

        public Link GetLink(string propertyName)
        {
            return CastPropertyValue<Link>(propertyName);
        }

        public Asset GetLinkedAsset(string propertyName)
        {
            return CastPropertyValue<Asset>(propertyName);
        }

        public Entry GetLinkedEntry(string propertyName)
        {
            return CastPropertyValue<Entry>(propertyName);
        }

        private T CastPropertyValue<T>(string propertyName)
        {
            return GetJObject()[propertyName].ToObject<T>();
        }

        private JObject GetJObject()
        {
            if (_jObject != null) return _jObject;
            lock (Lock)
            {
                _jObject = new JObject(Fields);
            }
            return _jObject;
        }
    }
}
