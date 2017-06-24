using CatApiWrapper.RequestBuilders;
using CatApiWrapper.Responses;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

namespace CatApiWrapper
{
    public class CatClient
    {
        /// <summary>
        /// Creates an instance of a CatClient; the basis for all API calls ʅ(°‿°)ʃ
        /// </summary>
        public CatClient() { }

        /// <summary>
        /// Calls the CatApi and returns a list of images.
        /// </summary>
        /// <param name="request">A <see cref="GetRequestBuilder"/> object containing request parameters.</param>
        /// <exception cref="InvalidRequestException">Thrown if any required parameters are null.</exception>
        /// <returns>A list of cat images :D</returns>
        public IEnumerable<GetResponse.Image> GetImages(GetRequestBuilder request)
        {
            var uri = request.Build();
            var response = Get<GetResponse.Response>(uri);
            return response.Data.Images;
        }

        /// <summary>
        /// This lets you or one of your users score an image 1-10.
        /// </summary>
        /// <param name="request">A <see cref="VoteRequestBuilder"> object containing request parameters.</see></param>
        /// <exception cref="InvalidRequestException">Thrown if any required parameters are null.</exception>
        /// <returns></returns>
        public IEnumerable<VoteResponse.Vote> Vote(VoteRequestBuilder request)
        {
            var uri = request.Build();
            var response = Get<VoteResponse.Response>(uri);
            return response.Data.Votes;
        }

        /// <summary>
        /// This lets you or one of your Users favourite an Image
        /// </summary>
        /// <param name="request">A <see cref="FavouriteRequestBuilder"/> object containing request parameters.</param>
        /// <exception cref="InvalidRequestException">Thrown if any required parameters are null.</exception>
        /// <returns></returns>
        public FavouriteResponse.Response Favourite(FavouriteRequestBuilder request)
        {
            var uri = request.Build();
            var response = Get<FavouriteResponse.Response>(uri);
            return response;
        }

        /// <summary>
        /// This gets all the votes cast with your api_key
        /// </summary>
        /// <param name="request">A <see cref="GetVotesRequestBuilder"/> object containing request parameters.</param>
        /// <exception cref="InvalidRequestException">Thrown if any required parameters are null.</exception>
        /// <returns></returns>
        public IEnumerable<GetVotesResponse.Image> GetVotes(GetVotesRequestBuilder request)
        {
            var uri = request.Build();
            var response = Get<GetVotesResponse.Response>(uri);
            return response.Data.Images;
        }

        /// <summary>
        /// This gets all the favourites set with your api_key
        /// </summary>
        /// <param name="request">A <see cref="GetFavouritesRequestBuilder"/> object containing request parameters.</param>
        /// <exception cref="InvalidRequestException">Thrown if any required parameters are null.</exception>
        /// <returns></returns>
        public IEnumerable<GetFavouritesResponse.Image> GetFavourite(GetFavouritesRequestBuilder request)
        {
            var uri = request.Build();
            var response = Get<GetFavouritesResponse.Response>(uri);
            return response.Data.Images;
        }

        internal static TResult ReadResult<TResult>(HttpResponseMessage response) where TResult : new()
        {
            var serialiser = new XmlSerializer(typeof(TResult));
            var reader = XmlReader.Create(new StringReader(response.Content.ReadAsStringAsync().Result));
            return (TResult)serialiser.Deserialize(reader);
        }

        private static T Get<T>(string uri) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = Get(uri, client);
                return ReadResult<T>(response);
            }
        }

        private static HttpResponseMessage Get(string uri, HttpClient client)
        {
            var responseMessage = client.GetAsync(uri);
            return responseMessage.Result;
        }
    }
}
