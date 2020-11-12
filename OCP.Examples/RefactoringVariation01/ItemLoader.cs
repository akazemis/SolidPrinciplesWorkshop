using System.Collections.Generic;
using Newtonsoft.Json;

namespace OCP.Examples.RefactoringVariation01
{
    // This technique uses abstract base classes and
    // virtual methods to make the class follow the OCP

    // This approach allows you to extend the serialization by overriding
    // the methods with your own implementation
    public class ItemLoader<TItem> : ItemLoaderBase<TItem>
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