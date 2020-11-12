using System.Collections.Generic;
using System.IO;

namespace OCP.Examples.RefactoringVariation01
{
    public abstract class ItemLoaderBase<TItem>
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
        protected abstract IEnumerable<TItem> Deserialize(string text);

        protected abstract string Serialize(IEnumerable<TItem> items);
    }
}