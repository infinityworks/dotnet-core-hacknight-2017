using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace CatApi
{
    [XmlRoot("response")]
    public class Response
    {
        [XmlElement("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [XmlArray("images")]
        public List<Image> Images { get; set; } = new List<Image>();
    }

    [XmlType("image")]
    public class Image
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("url")]
        public string Url { get; set; }
    }
}