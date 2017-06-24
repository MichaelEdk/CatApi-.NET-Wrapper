using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatApiWrapper.RequestBuilders
{
    public abstract class BaseRequestBuilder : IRequestBuilder
    {
        private const string BaseUri = "http://thecatapi.com/api/images/";

        protected const string ApiKeyParam = "api_key";
        protected const string SubIdParam = "sub_id";
        protected const string ImageIdParam = "image_id";
        protected const string FormatParam = "format";
        protected const string ResultsPerPageParam = "results_per_page";
        protected const string TypeParam = "type";
        protected const string CategoryParam = "category";
        protected const string SizeParam = "size";
        protected const string ActionParam = "action";
        protected const string ScoreParam = "score";

        protected const string InvalidRequestExceptionMessage = "One of the required parameters was missing or null";

        /// <summary>
        /// Checks that all fields that are required for the query are populated.
        /// </summary>
        /// <param name="requiredParams">A list of the names of the required parameters.</param>
        /// <param name="request">A list of the parameters and their values in the current request.</param>
        /// <returns><c>True</c> if all required parameters are present.</returns>
        public bool AreAllRequiredFieldsPresent(IEnumerable<string> requiredParams, IDictionary<string, string> request)
        {
            foreach (var param in requiredParams)
            {
                if (!request.Keys.Contains(param) || request[param] == null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a Uri as a string, built from the method name (e.g., getvotes), and
        /// the request parameters
        /// </summary>
        /// <param name="method">The name of the method, e.g., getvotes</param>
        /// <param name="request">A dictionary containing all th request parameters and their values.</param>
        /// <returns></returns>
        public string Build(string method, IDictionary<string, string> request)
        {
            var queryString = $"{BaseUri}{method}?";
            foreach (var kvp in request)
            {
                if (kvp.Value != null)
                {
                    queryString += $"{kvp.Key}={kvp.Value}&";
                }
            }

            return queryString;
        }
    }
}
