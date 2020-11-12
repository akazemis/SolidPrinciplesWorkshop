using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SRP.Examples.Example02
{
    // Does this class follow the SRP? How many responsibilities does it have?
    public class ItemLoader<TItem>
    {
        private readonly List<TItem> _loadedItems = new List<TItem>();

        public void LoadAllData()
        {
            var filename = "data.dat";
            var text = File.ReadAllText(filename);
            _loadedItems.AddRange(Deserialize(text));
        }

        public void SaveAllData()
        {
            var filename = "data.dat";
            var text = Serialize(_loadedItems);
            File.WriteAllText(filename, text);
        }

        public IEnumerable<TItem> LoadedItems => _loadedItems;
        private IEnumerable<TItem> Deserialize(string text)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<TItem>>(text);
            return items;
        }

        private string Serialize(IEnumerable<TItem> items)
        {
            return JsonConvert.SerializeObject(items);
        }
    }
}