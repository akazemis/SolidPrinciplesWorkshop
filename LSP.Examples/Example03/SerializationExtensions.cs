using System.Collections.Generic;

namespace LSP.Examples.Example03
{
    public static class SerializationExtensions
    {
        public static IEnumerable<TItem> LoadItems<TItem>(this ISerializer<TItem> serializer,
            IFileSystem fileSystem, string filename)
        {
            var text = fileSystem.ReadAllText(filename);
            return serializer.Deserialize(text);
        }

        public static void SaveItems<TItem>(this IEnumerable<TItem> items,
            ISerializer<TItem> serializer, IFileSystem fileSystem,
            string filename)
        {
            var text = serializer.Serialize(items);
            fileSystem.WriteAllText(filename, text);
        }
    }
}