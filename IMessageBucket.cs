using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IMessageBucket<TMessage, in TBucket> : IBucket
    {
        Task<IReadOnlyCollection<TMessage>> ReadAllAsync();
        Task<TMessage> ReadAsync(MessageId id);
        Task InsertAsync(TBucket message);
        IBucketReader<TMessage, TBucket> GetReader();
    }
}