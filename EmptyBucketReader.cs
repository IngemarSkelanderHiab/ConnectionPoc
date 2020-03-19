using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class EmptyBucketReader<T> : IBucketReader<T, Signal>
    {
        public Task<IReadOnlyCollection<T>> ReadAllAsync()
        {
            return Task.FromResult<IReadOnlyCollection<T>>(new T[0]);
        }
    }
}