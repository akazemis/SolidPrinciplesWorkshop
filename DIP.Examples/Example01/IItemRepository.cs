using System.Collections.Generic;

namespace DIP.Examples.Example01
{
    public interface IItemRepository
    {
        void SaveToDisk(IEnumerable<Item> items);
        IEnumerable<Item> LoadFromDisk();
    }
}