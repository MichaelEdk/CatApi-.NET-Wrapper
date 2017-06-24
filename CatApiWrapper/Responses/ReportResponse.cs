using System.Xml.Serialization;

namespace CatApiWrapper.Responses
{
    public class ReportResponse
    {
        [XmlType("report")]
        public class Report
        {
            [XmlElement("reason")]
            public string Reason { get; set; }

            [XmlElement("image_id")]
            public string ImageId { get; set; }

            [XmlElement("sub_id")]
            public string SubId { get; set; }
        }

        [XmlType("data")]
        public class Data
        {
            [XmlArray("reports")]
            [XmlArrayItem("report", typeof(Report))]
            public Report[] Reports { get; set; }
        }

        [XmlType("response")]
        public class Response
        {
            [XmlElement("data")]
            public Data Data { get; set; }
        }
    }
}
