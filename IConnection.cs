using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    public interface IConnection
    {
        int Id { get; }
        Task GetStatusAsync();
        Task ConnectAsync();
        Task DisconnectAsync();
    }
}
