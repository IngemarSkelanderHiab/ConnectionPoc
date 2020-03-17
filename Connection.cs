using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public class Connection : IConnection
    {
        public int Id { get; } = Guid.NewGuid().GetHashCode(); // Not prod ready!

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
