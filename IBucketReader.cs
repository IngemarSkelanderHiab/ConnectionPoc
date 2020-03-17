using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IBucketReader<T>
    {        
        Task<IReadOnlyCollection<T>> ReadAllAsync();                
    }
}