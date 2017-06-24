using System.Xml.Serialization;

namespace CatApiWrapper.Responses
{
    public class GetResponse
    {
        [XmlType("image")]
        public class Image
        {
            [XmlElement("url")]
            public string Url { get; set; }

            [XmlElement("id")]
            public string Id { get; set; }

            [XmlElement("source_url")]
            public string SourceUrl { get; set; }
        }

        [XmlType("data")]
        public class Data
        {
            [XmlArray("images")]
            [XmlArrayItem("image", typeof(Image))]
            public Image[] Images { get; set; }
        }

        [XmlRoot("response")]
        public class Response
        {
            [XmlElement("data")]
            public Data Data { get; set; }
        }
    }
}
