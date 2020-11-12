using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ISP.Examples.Example03
{
    public class DataStore<TKey, TItem> : IDataStore<TKey, TItem> , IFlushable, ITryFetch<TKey, TItem>
        where TItem : class
    {
        private readonly Dictionary<TKey, TItem> _items = new Dictionary<TKey, TItem>();

        public void AddItem(TKey key, TItem item)
        {
            _items.Add(key, item);
        }

        public IEnumerable<TKey> Keys => _items.Keys;

        public bool Contains(TKey key)
        {
            return _items.ContainsKey(key);
        }

        public bool TryGet(TKey key, out TItem item)
        {
            item = default(TItem);

            if (!Contains(key))
                return false;

            item = _items[key];
            return true;
        }

        public void Flush()
        {
            // Save the entries as a JSON file to disk
            var filename = "datastore.dat";
            var json = JsonConvert.SerializeObject(_items);
            File.WriteAllText(filename, json);
        }
    }
}