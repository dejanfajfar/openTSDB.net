namespace openTsdbNet.models
{
    public class SingleDataPoint<TVal>
    {
        public SingleDataPoint()
        {
            Tags = new TagsCollection();
        } 

        public string Metric { get; set; }

        public int Timestamp { get; set; }

        public TVal Value { get; set; }

        public TagsCollection Tags { get; }
    }
}