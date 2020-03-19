using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class ParameterBucketReader : IBucketReader<Parameter, Signal>
    {
        private readonly IMessageBucket<Parameter, Signal> _bucket;

        public ParameterBucketReader(IMessageBucket<Parameter, Signal> bucket)
        {
            _bucket = bucket;
        }

        public async Task<IReadOnlyCollection<Parameter>> ReadAllAsync()
        {
            var parameters = await _bucket.ReadAllAsync();
            return parameters;
        }
    }
}