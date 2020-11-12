using System.Collections.Generic;
using System.IO;
using DIP.Examples.Example02;
using LightInject;
using Newtonsoft.Json;

namespace DIP.Examples.Example03
{
    public interface IItemRepository
    {
        void Save(IEnumerable<Item> items);
        IEnumerable<Item> LoadItems();
    }

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

    public class JsonSerializer<TItem> : ISerializer<TItem>
    {
        public virtual IEnumerable<TItem> Deserialize(string text)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<TItem>>(text);
            return items;
        }

        public virtual string Serialize(IEnumerable<TItem> items)
        {
            return JsonConvert.SerializeObject(items);
        }
    }
    public interface IFileSystem
    {
        string ReadAllText(string filename);
        void WriteAllText(string filename, string text);
    }

    public interface ISerializer<TItem>
    {
        IEnumerable<TItem> Deserialize(string text);
        string Serialize(IEnumerable<TItem> items);
    }

    public class FileSystem : IFileSystem
    {
        public string ReadAllText(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void WriteAllText(string filename, string text)
        {
            File.WriteAllText(filename, text);
        }
    }

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

    public static class Environment
    {
        public static bool IsTestEnvironment
        {
            get;
            set;
        } = false;
    }
    public class SampleApp
    {
        public static void Run()
        {
            // Setup the container
            var container = new ServiceContainer();
            container.Register<IFileSystem, FileSystem>();
            container.Register<ISerializer<Item>, JsonSerializer<Item>>();

            if (Environment.IsTestEnvironment)
                container.Register<IItemRepository, InMemoryRepository>();
            else
                container.Register<IItemRepository, ItemRepository>();


            // Create the item repository itself
            var repository = container.GetInstance<IItemRepository>();
            
            // TODO: Do something with the repository here
        }
    }
}