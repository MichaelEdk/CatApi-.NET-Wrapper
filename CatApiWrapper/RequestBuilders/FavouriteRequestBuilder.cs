using System.Collections.Generic;

namespace CatApiWrapper.RequestBuilders
{
    public class FavouriteRequestBuilder : BaseRequestBuilder
    {
        private readonly IEnumerable<string> _requiredParams = new List<string>
        {
            ApiKeyParam,
            ImageIdParam
        };

        private readonly IDictionary<string, string> _request = new Dictionary<string, string>();

        /// <summary>
        /// This lets you or one of your Users favourite an Image.
        /// </summary>
        /// <param name="apiKey">Your API key.</param>
        /// <param name="imageId">Unique id of the image to favourite or un-favourite</param>
        public FavouriteRequestBuilder(string apiKey, string imageId)
        {
            _request.Add(ApiKeyParam, apiKey);
            _request.Add(ImageIdParam, imageId);
        }

        /// <summary>
        /// This allows you to say whether to add a favourite or remove it
        /// </summary>
        /// <param name="favouriteAction"><see cref="FavouriteAction"/>Add or Remove</param>
        /// <returns></returns>
        public FavouriteRequestBuilder WithAction(FavouriteAction favouriteAction)
        {
            _request.Add(ActionParam, favouriteAction.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// This allows you to favourite this Image once per User.
        /// </summary>
        /// <param name="subId">Any value you wish to associate with this, could be a unique id you have for one of your Users like a facebook id.</param>
        /// <returns></returns>
        public FavouriteRequestBuilder WithSubId(string subId)
        {
            _request.Add(SubIdParam, subId);
            return this;
        }

        /// <summary>
        /// Converts the request builder object into a query string.
        /// </summary>
        /// <returns>A string uri.</returns>
        /// <exception cref="InvalidRequestException"></exception>
        public string Build()
        {
            if (!AreAllRequiredFieldsPresent(_requiredParams, _request))
            {
                throw new InvalidRequestException(InvalidRequestExceptionMessage);
            }
            return Build("favourite", _request);
        }
    }

    public enum FavouriteAction
    {
        Add,
        Remove
    }
}
