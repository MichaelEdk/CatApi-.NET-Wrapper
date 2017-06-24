using System.Collections.Generic;

namespace CatApiWrapper.RequestBuilders
{
    public class ReportRequestBuilder : BaseRequestBuilder
    {
        private readonly IEnumerable<string> _requiredParams = new List<string>
        {
            ApiKeyParam,
            ImageIdParam
        };

        private readonly IDictionary<string, string> _request = new Dictionary<string, string>();

        /// <summary>
        /// This allows you to report an Image so it will not show up again when you make a get request with your api_key.
        /// </summary>
        /// <param name="apiKey">Your Api Key</param>
        /// <param name="imageId">Unique id of the image to report</param>
        public ReportRequestBuilder(string apiKey, string imageId)
        {
            _request.Add(ApiKeyParam, apiKey);
            _request.Add(ImageIdParam, imageId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            if (!AreAllRequiredFieldsPresent(_requiredParams, _request))
            {
                throw new InvalidRequestException(InvalidRequestExceptionMessage);
            }
            return Build("report", _request);
        }

        /// <summary>
        /// Adds the sub_id parameter to the query string.
        /// </summary>
        /// <param name="subId"></param>
        /// <returns></returns>
        public ReportRequestBuilder WithSubId(string subId)
        {
            _request.Add(new KeyValuePair<string, string>(SubIdParam, subId));
            return this;
        }
    }
}
