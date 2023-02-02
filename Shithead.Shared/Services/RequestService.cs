using Blazored.LocalStorage;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shithead.Shared.Services
{
    public class RequestService : IRequestService
    {
        private readonly ILocalStorageService _localStorage;

        private string ApiUrl => "https://localhost:44359/";

        public RequestService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
        }

        /// <inheritdoc/>
        public async Task<IFlurlRequest> CreateRequest(string resource, string apiPathSegment) => await CreateRequest(resource, new Dictionary<string, string>(), apiPathSegment);

        /// <inheritdoc/>
        public async Task<IFlurlRequest> CreateRequest(string resource, Dictionary<string, string> queryParams, string apiPathSegment)
        {
            var url = new Url(ApiUrl)
                .AppendPathSegment(apiPathSegment)
                .AppendPathSegment(resource);

            if (queryParams.Any()) url.SetQueryParams(queryParams);

            var jwt = await _localStorage.GetItemAsync<string>("jwt");
            if (string.IsNullOrEmpty(jwt)) return new FlurlRequest(url);

            return url.WithOAuthBearerToken(jwt);
        }

        /// <inheritdoc/>
        public async Task<IFlurlRequest> CreateRequest(string resource, Dictionary<string, Guid> queryParams, string apiPathSegment)
        {
            var url = new Url(ApiUrl)
                .AppendPathSegment(apiPathSegment)
                .AppendPathSegment(resource);

            if (queryParams.Any()) url.SetQueryParams(queryParams);

            var jwt = await _localStorage.GetItemAsync<string>("jwt");
            if (string.IsNullOrEmpty(jwt)) return new FlurlRequest(url);

            return url.WithOAuthBearerToken(jwt);
        }
    }
}
