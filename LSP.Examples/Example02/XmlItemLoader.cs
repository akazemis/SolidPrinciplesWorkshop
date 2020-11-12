using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Newtonsoft.Json;

namespace LSP.Examples.Example02
{
    public class XmlItemLoader<TItem> : ItemLoaderBase<TItem>
    {
        protected override IEnumerable<TItem> Deserialize(string text)
        {
            var xml = text;
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var json = JsonConvert.SerializeXmlNode(doc);
            return JsonConvert.DeserializeObject<IEnumerable<TItem>>(json);
        }

        protected override string Serialize(IEnumerable<TItem> items)
        {
            throw new NotSupportedException("Sorry, I don't serialize items into XML");
        }
    }
}