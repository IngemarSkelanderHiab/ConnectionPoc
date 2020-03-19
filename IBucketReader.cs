using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IBucketReader<T, in Tin>
    {        
        Task<IReadOnlyCollection<T>> ReadAllAsync();                
    }
}