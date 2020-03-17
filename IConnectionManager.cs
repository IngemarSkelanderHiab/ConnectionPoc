using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IConnectionManager
    {
        Task<IConnection> GetConnectionAsync(int id);
        Task<IConnection> CreateConnectionAsync<T>(IPrincipal principal, T configuration);
        Task<IConnection> CreateConnectionAsync(IPrincipal principal);
        Task DeleteConnectionAsync(int id);
    }
}
