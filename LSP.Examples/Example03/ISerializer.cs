using System.Collections.Generic;

namespace LSP.Examples.Example03
{
    public interface ISerializer<TItem>
    {
        IEnumerable<TItem> Deserialize(string text);
        string Serialize(IEnumerable<TItem> items);
    }
}