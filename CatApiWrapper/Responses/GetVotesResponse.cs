using System.Xml.Serialization;

namespace CatApiWrapper.Responses
{
    public class GetVotesResponse
    {
        [XmlType("image")]
        public class Image
        {
            [XmlElement("sub_id")]
            public string SubId { get; set; }

            [XmlElement("created")]
            public string Created { get; set; }

            [XmlElement("score")]
            public int Score { get; set; }
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
