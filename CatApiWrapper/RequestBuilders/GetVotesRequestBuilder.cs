using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatApiWrapper.RequestBuilders
{
    public class GetVotesRequestBuilder : BaseRequestBuilder
    {
        private readonly IEnumerable<string> _requiredParams = new List<string>
        {
            ApiKeyParam
        };

        private readonly IDictionary<string, string> _request = new Dictionary<string, string>();

        /// <summary>
        /// This gets all the votes cast with your api_key
        /// </summary>
        /// <param name="apiKey">Your API Key.</param>
        public GetVotesRequestBuilder(string apiKey)
        {
            _request.Add(ApiKeyParam, apiKey);
        }

        /// <summary>
        /// Builds the request URL, if all required fields are present.
        /// </summary>
        /// <exception cref="InvalidRequestException">Thrown if a required field is not present or is null.</exception>
        /// <returns>The request URL.</returns>
        public string Build()
        {
            if (!Validate())
            {
                throw new InvalidRequestException(InvalidRequestExceptionMessage);
            }
            return Build("getvotes", _request);
        }

        /// <summary>
        /// Adds the sub_id parameter to the query.
        /// </summary>
        /// <param name="subId">If this is passed, then only votes cast with this sub_id will be returned</param>
        /// <returns></returns>
        public GetVotesRequestBuilder WithSubId(string subId)
        {
            _request.Add(SubIdParam, subId);
            return this;
        }

        private bool Validate()
        {
            return AreAllRequiredFieldsPresent(_requiredParams, _request);
        }
    }
}
