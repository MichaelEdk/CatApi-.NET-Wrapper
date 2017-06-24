using System.Xml.Serialization;

namespace CatApiWrapper.Responses
{
    public class FavouriteResponse
    {
        [XmlType("apierror")]
        public class ApiError
        {
            [XmlElement("message")]
            public string Message { get; set; }
        }

        [XmlType("data")]
        public class Data { }

        [XmlType("response")]
        public class Response
        {
            [XmlElement("data")]
            public Data Data { get; set; }

            [XmlElement("apierror")]
            public ApiError ApiError { get; set; }
        }
    }
}
