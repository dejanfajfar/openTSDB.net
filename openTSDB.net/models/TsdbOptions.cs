using System;

namespace openTSDB.net.Models
{
    public class TsdbOptions
    {
        public Uri OpenTsdbServerUri { get; set; }

        public TagsCollection DefaultTags { get; set; } = new TagsCollection();
    }
}