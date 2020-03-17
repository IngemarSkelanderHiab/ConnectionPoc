using System;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class Connection : IConnection
    {
        public ConnectionId Id { get; } = ConnectionId.Create();

        public Task ConnectAsync()
        {
            return Task.CompletedTask;
        }

        public Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetStatusAsync()
        {
            throw new NotImplementedException();
        }
    }
}