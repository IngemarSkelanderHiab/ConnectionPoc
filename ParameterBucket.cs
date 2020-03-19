//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ConnectionPoc
//{
//    public class ParameterBucket : IMessageBucket<Parameter, Signal>, IMessageBucket<Variable, Signal>
//    {
//        private readonly IDictionary<MessageId, Parameter> _parameters = new ConcurrentDictionary<MessageId, Parameter>();

//        public ParameterBucket()
//        {
//        }

//        private ParameterBucket(IDictionary<MessageId, Parameter> parameters)
//        {
//            _parameters = parameters;
//        }

//        public int Count => _parameters.Count;

//        public Task InsertAsync(Parameter parameter)
//        {
//            _parameters.Add(parameter.Id, parameter);
//            return Task.CompletedTask;
//        }

//        public Task InsertAsync(Variable message)
//        {
//            throw new System.NotImplementedException();
//        }

//        public IBucketReader<Parameter> GetReader()
//        {
//            // If we like, we can constantly return copies of the bucket values, so as to avoid the issue of thread safety
//            var bucketCopy = new ParameterBucket(new Dictionary<MessageId, Parameter>(_parameters));
//            return new ParameterBucketReader(bucketCopy);

//            // ... Or we can just return new ParameterBucketReader(this), but then it's even more important to think about thread safety than before.
//        }

//        public Task<IReadOnlyCollection<Parameter>> ReadAllAsync()
//        {
//            return Task.FromResult<IReadOnlyCollection<Parameter>>(_parameters.Values.ToArray());
//        }

//        Task<Variable> IMessageBucket<Variable>.ReadAsync(MessageId id)
//        {
//            throw new System.NotImplementedException();
//        }

//        Task<IReadOnlyCollection<Variable>> IMessageBucket<Variable>.ReadAllAsync()
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<Parameter> ReadAsync(MessageId id)
//        {
//            var value = _parameters.ContainsKey(id)
//                ? _parameters[id]
//                : null;

//            return Task.FromResult(value);
//        }

//        IBucketReader<Variable> IMessageBucket<Variable>.GetReader()
//        {
//            var bucketCopy = new ParameterBucket(new Dictionary<MessageId, Parameter>(_parameters));
//            return new VariableBucketReader(bucketCopy);
//        }
//    }
//}