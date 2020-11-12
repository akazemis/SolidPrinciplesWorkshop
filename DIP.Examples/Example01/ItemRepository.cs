using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DIP.Examples.Example01
{
    public class ItemRepository : IItemRepository
    {
        public void SaveToDisk(IEnumerable<Item> items)
        {
            var json = JsonConvert.SerializeObject(items);
            File.WriteAllText("itemdata.json", json);
        }

        public IEnumerable<Item> LoadFromDisk()
        {
            var json = File.ReadAllText("itemdata.json");
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(json);
        }
    }
}