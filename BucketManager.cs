using System.Collections.Generic;
using System.Linq;

namespace ConnectionPoc
{
    internal class BucketManager : IBucketManager // Eller basklass, whatever?
    {
        private readonly IDictionary<ConnectionId, IList<IBucket>> _buckets = new Dictionary<ConnectionId, IList<IBucket>>();

        public void Add(ConnectionId key, IBucket bucket)
        {
            IList<IBucket> bucketsWithKey;
            if (_buckets.ContainsKey(key))
            {
                bucketsWithKey = _buckets[key];
            }
            else
            {
                bucketsWithKey = new List<IBucket>();
                _buckets.Add(key, bucketsWithKey);
            }

            bucketsWithKey.Add(bucket);
        }

        public IBucketReader<T> GetReader<T>(ConnectionId key)
        {
            if (_buckets.ContainsKey(key))
            {
                var bucketsWithKey = _buckets[key];
                var bucketOfType = bucketsWithKey
                    .Single(bucket => bucket is IMessageBucket<T>) as IMessageBucket<T>;

                return bucketOfType.GetReader();
            }

            return new EmptyBucketReader<T>();
        }
    }
}