using System.Collections.Generic;

namespace DIP.Examples.Example01
{
    // Do these classes follow the dependency inversion principle? Y/N?
    public class ItemRepositoryConsumer
    {
        private readonly IItemRepository _itemRepository;
        private readonly List<Item> _loadedItems = new List<Item>();

        public ItemRepositoryConsumer(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> LoadedItems => _loadedItems;
        public void Save(Item item)
        {
            _itemRepository.SaveToDisk(new[]{item});
        }

        public void ReloadAll()
        {
            // Clear the existing items in memory
            _loadedItems.Clear();

            // Reload the items from the repository
            var loadedItems = _itemRepository.LoadFromDisk();
            _loadedItems.AddRange(loadedItems);
        }
    }
}