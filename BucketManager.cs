using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class BucketManager : IBucketManager
    {
        private readonly IDictionary<int, BaseBucket> _buckets = new Dictionary<int, BaseBucket>();

        public void Add(int key, BaseBucket bucket)
        {
            _buckets.Add(key, bucket);
        }

        public IBucketReader<T> GetReader<T>(int key)
        {
            if (!_buckets.ContainsKey(key)) return null;
            
            switch (_buckets[key])
            {
                case ParameterBucket bucket:
                    return (IBucketReader<T>)new ParameterBucketReader(bucket);
                case VariableBucket bucket:
                    return (IBucketReader<T>)new VariableBucketReader(bucket);
                default:
                    return null;
            }
        }
    }
}