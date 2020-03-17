using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class BucketManager : IBucketManager
    {
        private IDictionary<int, object> _buckets = new Dictionary<int, object>();

        public void Add(int key, object bucket)
        {
            _buckets.Add(key, bucket);
        }

        public IBucketReader<T> GetReader<T>(int key)
        {
            if (typeof(T) == typeof(Parameter))
            {
                if (_buckets.ContainsKey(key))
                {
                    var bucket = _buckets[key] as ParameterBucket;
                    if (bucket != null)
                    {
                        return (IBucketReader<T>)new ParameterBucketReader(bucket);
                    }                    
                }
                return null;                
            }
            throw new InvalidOperationException();
        }
    }
}