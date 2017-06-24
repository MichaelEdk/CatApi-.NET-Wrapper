using System.Collections.Generic;
using System.Linq;

namespace CatApiWrapper.RequestBuilders
{
    public class GetRequestBuilder : BaseRequestBuilder
    {
        private readonly IDictionary<string, string> _request = new Dictionary<string, string>
        {
            // Currently this wrapper only supports the XML format.
            { FormatParam, Format.Xml.ToString().ToLower() }
        };
        public string Build()
        {
            return Build("get", _request);
        }

        /// <summary>
        /// Add the api_key parameter to the query string.
        /// </summary>
        /// <param name="apiKey">Your Api Key.</param>
        /// <returns></returns>
        public GetRequestBuilder WithApiKey(string apiKey)
        {
            _request.Add(ApiKeyParam, apiKey);
            return this;
        }

        /// <summary>
        /// Add the image_id param to the query string.
        /// </summary>
        /// <param name="id">Unique id of the Image to return.</param>
        /// <returns></returns>
        public GetRequestBuilder WithImageId(string id)
        {
            _request.Add(ImageIdParam, id);
            return this;
        }

        /// <summary>
        /// Adds the results_per_page parameter to the query string. Default: 1.
        /// </summary>
        /// <param name="resultsPerPage">The number of Cats to respond with.</param>
        /// <returns></returns>
        public GetRequestBuilder WithResultsPerPage(int resultsPerPage)
        {
            if (resultsPerPage < 1 || resultsPerPage > 100)
            {
                throw new InvalidRequestException($"Results per page of {resultsPerPage} is outside of the allowed range (1-100)");
            }
            _request.Add(ResultsPerPageParam, resultsPerPage.ToString());
            return this;
        }

        /// <summary>
        /// Adds the type parameter to the query string. Default: all types.
        /// </summary>
        /// <param name="types">A list of file types <see cref="ImageType"/> to return.</param>
        /// <returns></returns>
        public GetRequestBuilder WithType(IEnumerable<ImageType> types)
        {
            _request.Add(TypeParam, string.Join(",", types.Select(type => type.ToString().ToLower())));
            return this;
        }

        /// <summary>
        /// Adds the category parameter to the query string.
        /// </summary>
        /// <param name="category">Filter the Cats returned to those wearing hats, in space, in boxes etc. <see cref="Category"/></param>
        /// <returns></returns>
        public GetRequestBuilder WithCategory(Category category)
        {
            _request.Add(CategoryParam, category.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// Adds the size parameter to the query string.
        /// </summary>
        /// <param name="size">Size <see cref="Size"/> of returned Images, small = 250x, med = 500x, full = original size.</param>
        /// <returns></returns>
        public GetRequestBuilder WithSize(Size size)
        {
            _request.Add(SizeParam, size.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// Adds the sub_id parameter to the query string.
        /// </summary>
        /// <param name="subId">Passing this will return the value of any Favourite or Votes set with the same sub_id for the image.</param>
        /// <returns></returns>
        public GetRequestBuilder WithSubId(string subId)
        {
            _request.Add(SubIdParam, subId);
            return this;
        }
    }

    public enum Format
    {
        Xml,
        Html,
        Src
    }

    public enum ImageType
    {
        Jpg,
        Png,
        Gif
    }

    public enum Category
    {
        Hats,
        Space,
        Funny,
        Sunglasses,
        Boxes,
        Caturday,
        Ties,
        Dream,
        Kittens,
        Sinks,
        Clothes
    }

    public enum Size
    {
        Small,
        Med,
        Full
    }
}
