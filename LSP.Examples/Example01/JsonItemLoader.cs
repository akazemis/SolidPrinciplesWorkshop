using System.Collections.Generic;
using Newtonsoft.Json;

namespace LSP.Examples.Example01
{
    public class JsonItemLoader<TItem> : ItemLoaderBase<TItem>
    {
        protected override IEnumerable<TItem> Deserialize(string text)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<TItem>>(text);
            return items;
        }

        protected override string Serialize(IEnumerable<TItem> items)
        {
            return JsonConvert.SerializeObject(items);
        }
    }
}