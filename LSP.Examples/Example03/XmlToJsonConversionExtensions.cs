using System.Xml;
using Newtonsoft.Json;

namespace LSP.Examples.Example03
{
    public static class XmlToJsonConversionExtensions
    {
        public static string ToJson(this string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(doc);
        }

        public static string ToXml(this string json)
        {
            var node = JsonConvert.DeserializeXNode(json, "Root");
            return node == null ? string.Empty : node.ToString();
        }
    }
}