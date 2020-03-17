using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IBucketManager
    {
        IBucketReader<T> GetReader<T>(ConnectionId id);
        void Add(ConnectionId key, IBucket bucket);
    }
}