using System;
using openTSDB.net.Models;

namespace openTSDB.net
{
    public static class TagsCollectionExtentions
    {
        public static TagsCollection SetTag(this TagsCollection tagsCollection, string tagName, string tagValue)
        {
            if(string.IsNullOrWhiteSpace(tagName)) throw new ArgumentException("Tag name can not be null or empty", nameof(tagName));
            if(string.IsNullOrWhiteSpace(tagValue)) throw new ArgumentException("Tag value can not be null or empty", nameof(tagValue));

            tagsCollection[tagName] = tagValue;

            return tagsCollection;
        }

        public static TagsCollection SetHost(this TagsCollection tagsCollection, string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentException("The host name may not be null", nameof(hostName));
            }

            return tagsCollection.SetTag(TagNames.HOST, hostName);
        }

        public static TagsCollection SetHost(this TagsCollection tagsCollection, IHostNameProvider hostNameProvider)
        {
            return tagsCollection.SetTag(TagNames.HOST, hostNameProvider?.GetHostName());
        }
    }
}