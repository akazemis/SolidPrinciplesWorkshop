using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OCP.Examples.RefactoringVariation04
{
    public class ItemLoader<TItem>
    {
        private readonly List<TItem> _loadedItems = new List<TItem>();
        private readonly Func<string, IEnumerable<TItem>> _deserializeItems;
        private readonly Func<IEnumerable<TItem>, string> _serializeItems;

        private readonly Func<string, string> _readAllText;
        private readonly Action<string, string> _writeAllText;

        public ItemLoader() : this(JsonConvert.DeserializeObject<IEnumerable<TItem>>, 
            JsonConvert.SerializeObject, 
            File.ReadAllText, 
            File.WriteAllText)
        {
        }

        public ItemLoader(Func<string, IEnumerable<TItem>> deserializeItems, 
            Func<IEnumerable<TItem>, string> serializeItems, 
            Func<string, string> readAllText, 
            Action<string,string> writeAllText)
        {
            _deserializeItems = deserializeItems;
            _serializeItems = serializeItems;
            _readAllText = readAllText;
            _writeAllText = writeAllText;
        }

        public void LoadAllData()
        {
            var filename = "data.dat";
            var text = _readAllText(filename);
            _loadedItems.AddRange(Deserialize(text));
        }

        public void SaveAllData()
        {
            var filename = "data.dat";
            var text = Serialize(_loadedItems);
            _writeAllText(filename, text);
        }

        public IEnumerable<TItem> LoadedItems => _loadedItems;
        private IEnumerable<TItem> Deserialize(string text)
        {
            var items = _deserializeItems(text);
            return items;
        }

        private string Serialize(IEnumerable<TItem> items)
        {
            return _serializeItems(items);
        }
    }
}