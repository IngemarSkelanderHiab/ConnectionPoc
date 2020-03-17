using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class EmptyBucketReader<T> : IBucketReader<T>
    {
        public Task<IReadOnlyCollection<T>> ReadAllAsync()
        {
            return Task.FromResult<IReadOnlyCollection<T>>(new T[0]);
        }
    }
}