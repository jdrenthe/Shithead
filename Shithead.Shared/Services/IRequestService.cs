using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shithead.Shared.Services
{
    public interface IRequestService
    {
        /// <summary>
        /// Creates a request to the api.
        /// </summary>
        /// <param name="resource">Api method name as a string.</param>
        /// <param name="apiPathSegment">Api path segment as a string</param>
        /// <returns>A request to set up a connection with the api.</returns>
        Task<IFlurlRequest> CreateRequest(string resource, string apiPathSegment);

        /// <summary>
        /// Creates a request to the api.
        /// </summary>
        /// <param name="resource">Api method name as a string.</param>
        /// <param name="queryParams">Query parameters as a string</param>
        /// <param name="apiPathSegment">Api path segment as a string</param>
        /// <returns>A request to set up a connection with the api.</returns>
        Task<IFlurlRequest> CreateRequest(string resource, Dictionary<string, string> queryParams, string apiPathSegment);

        /// <summary>
        /// Creates a request to the api.
        /// </summary>
        /// <param name="resource">Api method name as a string.</param>
        /// <param name="queryParams">Query parameters as a string and Guid</param>
        /// <param name="apiPathSegment">Api path segment as a string</param>
        /// <returns>A request to set up a connection with the api.</returns>
        Task<IFlurlRequest> CreateRequest(string resource, Dictionary<string, Guid> queryParams, string apiPathSegment);
    }
}
