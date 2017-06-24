using System.Collections.Generic;

namespace CatApiWrapper.RequestBuilders
{
    public interface IRequestBuilder
    {
        /// <summary>
        /// Returns a Uri as a string, built from the method name (e.g., getvotes), and
        /// the request parameters
        /// </summary>
        /// <param name="method">The name of the method, e.g., getvotes</param>
        /// <param name="request">A dictionary containing all th request parameters and their values.</param>
        /// <returns></returns>
        string Build(string method, IDictionary<string, string> request);

        /// <summary>
        /// Checks that all fields that are required for the query are populated.
        /// </summary>
        /// <param name="requiredParams">A list of the names of the required parameters.</param>
        /// <param name="request">A list of the parameters and their values in the current request.</param>
        /// <returns><c>True</c> if all required parameters are present.</returns>
        bool AreAllRequiredFieldsPresent(IEnumerable<string> requiredParams, IDictionary<string, string> request);
    }
}
