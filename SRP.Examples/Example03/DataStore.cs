using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SRP.Examples.Example03
{
    // How many responsibilities does this class have?
    public class DataStore<TKey, TItem>
        where TItem : class
    {
        private readonly Dictionary<TKey, TItem> _items = new Dictionary<TKey, TItem>();

        public void AddItem(TKey key, TItem item)
        {
            _items.Add(key, item);
        }

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