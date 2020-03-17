using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class VariableBucketReader : IBucketReader<Variable>
    {
        private readonly IMessageBucket<Variable, int> _bucket;

        public VariableBucketReader(IMessageBucket<Variable, int> bucket)
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