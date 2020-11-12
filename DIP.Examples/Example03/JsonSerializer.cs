using System.Collections.Generic;
using Newtonsoft.Json;

namespace DIP.Examples.Example03
{
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
}