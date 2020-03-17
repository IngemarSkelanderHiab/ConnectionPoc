using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoc
{   
    /// <summary>
    ///     A message bucket is a place to store and subsequently read previously stored messages.
    /// </summary>
    /// <typeparam name="TMessage">The message generic type.</typeparam>
    /// <typeparam name="TIdentifier">The message identifier generic type.</typeparam>
    public interface IMessageBucket<TMessage, in TIdentifier>
    {
        int Count { get; }
        Task<IReadOnlyCollection<TMessage>> ReadAllAsync();
        Task<TMessage> ReadAsync(TIdentifier identifier);
        Task InsertAsync(TMessage message);
    }   
}
