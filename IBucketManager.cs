using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IBucketManager
    {
        IBucketReader<T> GetReader<T>(int connectionId);
        void Add(int key, BaseBucket bucket);
    }
}