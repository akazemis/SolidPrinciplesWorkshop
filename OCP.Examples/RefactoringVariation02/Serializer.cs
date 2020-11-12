using System.Collections.Generic;
using Newtonsoft.Json;

namespace OCP.Examples.RefactoringVariation02
{
    public class Serializer<TItem> : ISerializer<TItem>
    {
        public IEnumerable<TItem> Deserialize(string text)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<TItem>>(text);
            return items;
        }

        public string Serialize(IEnumerable<TItem> items)
        {
            return JsonConvert.SerializeObject(items);
        }
    }
}