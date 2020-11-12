using System.Collections.Generic;

namespace ISP.Examples.Example03
{
    public interface ITryFetch<TKey, TItem> where TItem : class
    {
        bool TryGet(TKey key, out TItem item);
        IEnumerable<TKey> Keys { get; }
    }
}