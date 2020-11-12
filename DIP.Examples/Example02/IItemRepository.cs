using System.Collections.Generic;

namespace DIP.Examples.Example02
{
    public interface IItemRepository
    {
        void Save(IEnumerable<Item> items);
        IEnumerable<Item> LoadItems();
    }
}