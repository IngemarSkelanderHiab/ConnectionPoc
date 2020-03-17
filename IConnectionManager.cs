using System.Security.Principal;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IConnectionManager
    {
        Task<IConnection> GetConnectionAsync(ConnectionId id);
        Task<IConnection> CreateConnectionAsync<T>(IPrincipal principal, T configuration);
        Task<IConnection> CreateConnectionAsync(IPrincipal principal);
        Task DeleteConnectionAsync(ConnectionId id);
    }
}