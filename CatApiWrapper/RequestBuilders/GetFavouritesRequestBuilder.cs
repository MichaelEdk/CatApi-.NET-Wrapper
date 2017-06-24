using System.Collections.Generic;

namespace CatApiWrapper.RequestBuilders
{
    public class GetFavouritesRequestBuilder : BaseRequestBuilder
    {
        private readonly IEnumerable<string> _requiredParams = new List<string>
        {
            ApiKeyParam
        };

        private readonly IDictionary<string, string> _request = new Dictionary<string, string>();

        /// <summary>
        /// This gets all the favourites set with your api_key.
        /// </summary>
        /// <param name="apiKey">Your Api Key.</param>
        public GetFavouritesRequestBuilder(string apiKey)
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
            if (!AreAllRequiredFieldsPresent(_requiredParams, _request))
            {
                throw new InvalidRequestException(InvalidRequestExceptionMessage);
            }
            return Build("getfavourites", _request);
        }

        /// <summary>
        /// Adds the sub_id parameter to the query.
        /// </summary>
        /// <param name="subId">If this is passed, then only the Favourites cast with this sub_id will be returned.</param>
        /// <returns></returns>
        public GetFavouritesRequestBuilder WithSubId(string subId)
        {
            _request.Add(SubIdParam, subId);
            return this;
        }
    }
}
