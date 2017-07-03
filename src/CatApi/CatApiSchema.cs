using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace CatApi
{
    public class Response
    {
        [XmlElement("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [XmlElement("images")]
        [XmlArray("image")]
        public List<Image> Images { get; set; } = new List<Image>();
    }

    public class Image
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("url")]
        public string Url { get; set; }
    }
}