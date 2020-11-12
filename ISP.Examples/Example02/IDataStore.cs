using System.Collections.Generic;

namespace ISP.Examples.Example02
{
    public interface IDataStore<TKey, TItem> where TItem : class
    {
        void AddItem(TKey key, TItem item);
        bool Contains(TKey key);
        IEnumerable<TKey> Keys { get; }
        bool TryGet(TKey key, out TItem item);
        void Flush();
    }
}