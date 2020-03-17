using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IConnection
    {
        ConnectionId Id { get; }
        Task GetStatusAsync();
        Task ConnectAsync();
        Task DisconnectAsync();
    }
}