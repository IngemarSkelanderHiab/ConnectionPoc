using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class SignalBucket : IMessageBucket<Parameter, Signal>, IMessageBucket<Variable, Signal>
    {
        private readonly IDictionary<MessageId, Signal> _signals = new ConcurrentDictionary<MessageId, Signal>();

        public SignalBucket()
        {
        }

        private SignalBucket(IDictionary<MessageId, Signal> parameters)
        {
            _signals = parameters;
        }

        public int Count => _signals.Count;

        Task<IReadOnlyCollection<Parameter>> IMessageBucket<Parameter, Signal>.ReadAllAsync()
        {
            var parameters = _signals.Values.Select(signal => new Parameter() { Id = signal.Id, Value = signal.ParameterValue });
            return Task.FromResult<IReadOnlyCollection<Parameter>>(parameters.ToArray());
        }

        Task<Variable> IMessageBucket<Variable, Signal>.ReadAsync(MessageId id)
        {
            var value = _signals.ContainsKey(id)
                    ? _signals[id]
                    : null;

            return Task.FromResult(new Variable { Id = value.Id, Value = value.VariableValue });
        }

        Task<Parameter> IMessageBucket<Parameter, Signal>.ReadAsync(MessageId id)
        {
            var value = _signals.ContainsKey(id)
                    ? _signals[id]
                    : null;

            return Task.FromResult(new Parameter { Id = value.Id, Value = value.ParameterValue });
        }

        Task<IReadOnlyCollection<Variable>> IMessageBucket<Variable, Signal>.ReadAllAsync()
        {
            var variables = _signals.Values.Select(signal => new Variable { Id = signal.Id, Value = signal.VariableValue });
            return Task.FromResult<IReadOnlyCollection<Variable>>(variables.ToArray());
        }

        public Task InsertAsync(Signal signal)
        {
            _signals.Add(signal.Id, signal);
            return Task.CompletedTask;
        }

        IBucketReader<Parameter, Signal> IMessageBucket<Parameter, Signal>.GetReader()
        {
            // If we like, we can constantly return copies of the bucket values, so as to avoid the issue of thread safety
            var bucketCopy = new SignalBucket(new Dictionary<MessageId, Signal>(_signals));
            return new ParameterBucketReader(bucketCopy);

            // ... Or we can just return new ParameterBucketReader(this), but then it's even more important to think about thread safety than before.
        }

        IBucketReader<Variable, Signal> IMessageBucket<Variable, Signal>.GetReader()
        {
            var bucketCopy = new SignalBucket(new Dictionary<MessageId, Signal>(_signals));
            return new VariableBucketReader(bucketCopy);
        }
    }
}