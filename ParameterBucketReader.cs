using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class ParameterBucketReader : IBucketReader<Parameter>
    {
        private readonly IMessageBucket<Parameter, int> _bucket;

        public ParameterBucketReader(IMessageBucket<Parameter, int> bucket)
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