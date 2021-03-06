﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class ParameterBucket : IMessageBucket<Parameter, int>
    {
        private IDictionary<int, Parameter> _parameters = new Dictionary<int, Parameter>();

        public int Count => _parameters.Count;

        public IEnumerator<Parameter> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Parameter parameter)
        {
            _parameters.Add(parameter.Id, parameter);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Parameter>> ReadAllAsync()
        {
            return Task.FromResult<IReadOnlyCollection<Parameter>>(_parameters.Values.ToArray());
        }

        public Task<Parameter> ReadAsync(int identifier)
        {
            return Task.FromResult(_parameters.ContainsKey(identifier) ? _parameters[identifier] : null);            
        }
    }
}