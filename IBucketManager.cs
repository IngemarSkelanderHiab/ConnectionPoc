using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IBucketManager<T> { }

    public interface ISignalBucketManager : IBucketManager<Signal>
    {
        IBucketReader<T, Signal> GetReader<T>(ConnectionId id);
        void Add(ConnectionId key, IBucket bucket);
    }

    public interface IParameterBucketManager : IBucketManager<Parameter>
    {
        IBucketReader<T, Parameter> GetReader<T>(ConnectionId id);
        void Add(ConnectionId key, IBucket bucket);
    }
}