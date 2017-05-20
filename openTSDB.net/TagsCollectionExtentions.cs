using System;
using openTSDB.net.Models;

namespace openTSDB.net
{
    public static class TagsCollectionExtentions
    {
        public static TagsCollection SetTag(this TagsCollection tagsCollection, string tagName, string tagValue)
        {
            if(string.IsNullOrWhiteSpace(tagName)) throw new ArgumentException(ErrorMessages.TAG_NAME_INVALID, nameof(tagName));
            if(string.IsNullOrWhiteSpace(tagValue)) throw new ArgumentException(ErrorMessages.TAG_VALUE_INVALID, nameof(tagValue));

            tagsCollection[tagName] = tagValue;

            return tagsCollection;
        }

        public static TagsCollection SetHost(this TagsCollection tagsCollection, string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName)) throw new ArgumentException(ErrorMessages.HOST_NAME_INVALID_ERROR_MESSAGE, nameof(hostName));

            return tagsCollection.SetTag(TagsCollection.HOST, hostName);
        }

        public static string GetHost(this TagsCollection tagsCollection)
        {
            return tagsCollection[TagsCollection.HOST];
        }

        public static TagsCollection ExtendWith(this TagsCollection first, TagsCollection second)
        {
            foreach (var keyValuePair in second)
            {
                first.SetTag(keyValuePair.Key, keyValuePair.Value);
            }

            return first;
        }
    }
}