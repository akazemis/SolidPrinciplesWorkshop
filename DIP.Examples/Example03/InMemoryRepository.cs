using System.Collections.Generic;
using DIP.Examples.Example02;

namespace DIP.Examples.Example03
{
    public class InMemoryRepository : IItemRepository
    {
        private readonly List<Item> _items = new List<Item>();
        public void Save(IEnumerable<Item> items)
        {
            _items.AddRange(items);
        }

        public IEnumerable<Item> LoadItems()
        {
            // The items are already loaded in memory, so just return what is there
            return _items;
        }
    }
}