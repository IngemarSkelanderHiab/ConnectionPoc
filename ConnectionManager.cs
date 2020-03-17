using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class ConnectionManager : IConnectionManager
    {
        public Task<IConnection> CreateConnectionAsync<T>(IPrincipal principal, T configuration)
        {
            var connection = new Connection();
            return Task.FromResult<IConnection>(connection);
        }

        public Task<IConnection> CreateConnectionAsync(IPrincipal principal)
        {
            return CreateConnectionAsync(principal, new NullConfiguration());
        }

        public Task DeleteConnectionAsync(ConnectionId id)
        {
            throw new NotImplementedException();
        }

        public Task<IConnection> GetConnectionAsync(ConnectionId id)
        {
            throw new NotImplementedException();
        }

        private class NullConfiguration
        {
        }
    }
}