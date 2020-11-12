using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DIP.Examples.Example02
{
    public class ItemRepository : IItemRepository
    {
        public void Save(IEnumerable<Item> items)
        {
            var json = JsonConvert.SerializeObject(items);
            File.WriteAllText("itemdata.json", json);
        }

        public IEnumerable<Item> LoadItems()
        {
            var json = File.ReadAllText("itemdata.json");
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(json);
        }
    }
}