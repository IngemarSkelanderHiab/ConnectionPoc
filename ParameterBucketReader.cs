using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class ParameterBucketReader : IBucketReader<Parameter>
    {
        private readonly IMessageBucket<Parameter> _bucket;

        public ParameterBucketReader(IMessageBucket<Parameter> bucket)
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