using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RecordPoint.Solid.CodingChallenge
{
    // Challenge - Using the SOLID principles, refactor this DataStore class so that it can:
    // 1) Store any type
    // 2) Be extended to support saving to other formats, such as binary formats or XML
    // 3) Be easily mocked
    // 4) Be reused in another class
    // 5) (After refactoring) be extended without a single edit on the original DataStore file
    public class DataStore
    {
        private readonly Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public IEnumerable<Item> AllItems => _items.Values;
        public void AddItem(string key, Item item)
        {
            _items.Add(key, item);
        }

        public bool Contains(string key)
        {
            return _items.ContainsKey(key);
        }

        public bool TryGet(string key, out Item item)
        {
            item = default(Item);

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