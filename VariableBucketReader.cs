using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class VariableBucketReader : IBucketReader<Variable, Signal>
    {
        private readonly IMessageBucket<Variable, Signal> _bucket;

        public VariableBucketReader(IMessageBucket<Variable, Signal> bucket)
        {
            _bucket = bucket;
        }

        public async Task<IReadOnlyCollection<Variable>> ReadAllAsync()
        {
            var variables = await _bucket.ReadAllAsync();
            return variables;
        }
    }
}