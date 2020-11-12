using System.Collections.Generic;

namespace LSP.Examples.Example03
{
    public class XmlSerializer<TItem> : JsonSerializer<TItem>
    {
        public override string Serialize(IEnumerable<TItem> items)
        {
            var json = base.Serialize(items);

            return json.ToXml();
        }

        public override IEnumerable<TItem> Deserialize(string text)
        {
            // Assume that the text is Xml 
            // and convert it to Json
            var json = text.ToJson();
            return base.Deserialize(json);
        }
    }
}