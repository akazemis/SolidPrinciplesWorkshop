using System.Collections.Generic;
using System.IO;

namespace OCP.Examples.RefactoringVariation02
{
    public class ItemLoader<TItem>
    {
        private readonly List<TItem> _loadedItems = new List<TItem>();
        private readonly ISerializer<TItem> _serializer;
        private IFileSystem _fileSystem;

        public ItemLoader(ISerializer<TItem> serializer, IFileSystem fileSystem)
        {
            _serializer = serializer;
            _fileSystem = fileSystem;
        }

        public void LoadAllData()
        {
            var filename = "data.dat";
            var text = _fileSystem.ReadAllText(filename);
            _loadedItems.AddRange(_serializer.Deserialize(text));
        }

        public void SaveAllData()
        {
            var filename = "data.dat";
            var text = _serializer.Serialize(_loadedItems);
            _fileSystem.WriteAllText(filename, text);
        }

        public IEnumerable<TItem> LoadedItems => _loadedItems;
        
    }
}