using System.Xml.Serialization;

namespace CatApiWrapper.Responses
{
    public class VoteResponse
    {
        [XmlType("vote")]
        public class Vote
        {
            [XmlElement("score")]
            public int Score { get; set; }

            [XmlElement("image_id")]
            public string ImageId { get; set; }

            [XmlElement("sub_id")]
            public string SubId { get; set; }

            [XmlElement("action")]
            public string Action { get; set; }
        }

        [XmlType("data")]
        public class Data
        {
            [XmlArray("votes")]
            [XmlArrayItem("vote", typeof(Vote))]
            public Vote[] Votes { get; set; }
        }

        [XmlRoot("response")]
        public class Response
        {
            [XmlElement("data")]
            public Data Data { get; set; }
        }
    }
}
