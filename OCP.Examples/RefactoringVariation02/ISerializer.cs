using System.Collections.Generic;

namespace OCP.Examples.RefactoringVariation02
{
    public interface ISerializer<TItem>
    {
        IEnumerable<TItem> Deserialize(string text);
        string Serialize(IEnumerable<TItem> items);
    }
}