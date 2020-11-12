using System.Collections.Generic;
using DIP.Examples.Example02;

namespace DIP.Examples.Example03
{
    public class ItemRepository : IItemRepository
    {
        private IFileSystem _fileSystem;
        private ISerializer<Item> _serializer;

        public ItemRepository(IFileSystem fileSystem, ISerializer<Item> serializer)
        {
            _fileSystem = fileSystem;
            _serializer = serializer;
        }

        public void Save(IEnumerable<Item> items)
        {
            var json = _serializer.Serialize(items);
            _fileSystem.WriteAllText("itemdata.json", json);
        }

        public IEnumerable<Item> LoadItems()
        {
            var json = _fileSystem.ReadAllText("itemdata.json");
            return _serializer.Deserialize(json);
        }
    }
}