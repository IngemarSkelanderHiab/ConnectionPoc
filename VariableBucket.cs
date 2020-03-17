using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class VariableBucket : BaseBucket, IMessageBucket<Variable, int>
    {
        private IDictionary<int, Variable> _variables = new Dictionary<int, Variable>();
        public Task<IReadOnlyCollection<Variable>> ReadAllAsync()
        {
            return Task.FromResult<IReadOnlyCollection<Variable>>(_variables.Values.ToArray());
        }

        public Task<Variable> ReadAsync(int identifier)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Variable message)
        {
            _variables.Add(message.Id, message);
            return Task.CompletedTask;
        }
    }
}