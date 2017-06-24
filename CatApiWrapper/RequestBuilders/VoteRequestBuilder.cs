using System.Collections.Generic;

namespace CatApiWrapper.RequestBuilders
{
    public class VoteRequestBuilder : BaseRequestBuilder
    {
        private readonly IEnumerable<string> _requiredParams = new List<string>
        {
            ApiKeyParam,
            ImageIdParam,
            ScoreParam
        };

        private readonly IDictionary<string, string> _request = new Dictionary<string, string>();

        /// <summary>
        /// This lets you or one of your users score an image 1-10
        /// </summary>
        /// <param name="apiKey">Your Api Key</param>
        /// <param name="imageId">Unique id of the image to vote on.</param>
        /// <param name="score">	The score you want to give to the image 1 = bad / 10 = good.</param>
        public VoteRequestBuilder(string apiKey, string imageId, int score)
        {
            if (score < 1 || score > 10)
            {
                throw new InvalidRequestException($"Score of {score} is not in the valid range (1 - 10)");
            }

            _request.Add(ApiKeyParam, apiKey);
            _request.Add(ImageIdParam, imageId);
            _request.Add(ScoreParam, score.ToString());
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
            return Build("vote", _request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subId"></param>
        /// <returns></returns>
        public VoteRequestBuilder WithSubId(string subId)
        {
            _request.Add(new KeyValuePair<string, string>(SubIdParam, subId));
            return this;
        }
    }
}
