using System.Collections.Generic;

namespace ISP.Examples.Example01
{
    public interface IItemLoader<TItem>
    {
        void LoadAllData();
        void SaveAllData();
        IEnumerable<TItem> LoadedItems { get; }
    }
}