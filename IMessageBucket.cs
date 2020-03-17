using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IMessageBucket<TMessage> : IBucket
    {
        Task<IReadOnlyCollection<TMessage>> ReadAllAsync();
        Task<TMessage> ReadAsync(MessageId id);
        Task InsertAsync(TMessage message);
        IBucketReader<TMessage> GetReader();
    }
}