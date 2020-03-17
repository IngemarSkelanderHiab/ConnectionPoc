using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class ConnectionManager : IConnectionManager
    {
        private class NullConfiguration {}
        
        public Task<IConnection> CreateConnectionAsync<T>(IPrincipal principal, T configuration)
        {
            var connection = new Connection();
            return Task.FromResult<IConnection>(connection);
        }

        public Task<IConnection> CreateConnectionAsync(IPrincipal principal)
        {
            return CreateConnectionAsync<NullConfiguration>(principal, null);
        }

        public Task DeleteConnectionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IConnection> GetConnectionAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
