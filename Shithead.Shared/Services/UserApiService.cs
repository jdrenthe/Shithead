using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Flurl.Http;
using Microsoft.AspNetCore.Components;
using Shithead.Shared.Models;
using Shithead.Shared.Models.Session;

namespace Shithead.Shared.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly IRequestService _requestService;

        private readonly ILocalStorageService _localStorage;

        private readonly NavigationManager _navigationManager;

        public UserApiService(IRequestService requestService,
                              ILocalStorageService localStorage,
                              NavigationManager navigationManager)
        {
            _requestService = requestService;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        #region User

        /// <inheritdoc/>
        public async Task<DataBundel<User>> GetUser()
        {
            var jwt = await _localStorage.GetItemAsync<string>("jwt");
            var uid = await _localStorage.GetItemAsync<string>("uid");
            var phh = await _localStorage.GetItemAsync<string>("phh");

            if (string.IsNullOrEmpty(jwt) || string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(phh)) return new DataBundel<User>(null, false, "User isn't logged in");

            SessionUser.IsLoading = true;

            var request = await _requestService.CreateRequest("GetUser", new Dictionary<string, string> { { "uid", uid }, { "phh", phh } }, "api/User");
            var result =  await request.GetJsonAsync<DataBundel<User>>();

            SessionUser.IsLoading = false;
            return result;
        }

        /// <inheritdoc/>
        public async Task<DataBundel<List<User>>> GetAllUsers()
        {
            var request = await _requestService.CreateRequest("GetAllUsers", "api/User");
            return await request.GetJsonAsync<DataBundel<List<User>>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<User>> GetUserById(Guid userId)
        {
            var request = await _requestService.CreateRequest("GetUserById", new Dictionary<string, string> { { "userId", userId.ToString() } }, "api/User");
            return await request.GetJsonAsync<DataBundel<User>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Credentials>> SingIn(SingIn singIn)
        {
            var request = await _requestService.CreateRequest("SingIn", "api/User");
            var result = await request.PostJsonAsync(singIn).ReceiveJson<DataBundel<Credentials>>();

            if (result.Success && result.Content != null) await SetCredentials(result.Content);

            return result;
        }

        /// <inheritdoc/>
        public async Task SingOut()
        {
            SessionUser.Data = null;

            await _localStorage.RemoveItemAsync("jwt");
            await _localStorage.RemoveItemAsync("uid");
            await _localStorage.RemoveItemAsync("phh");

            _navigationManager.NavigateTo($"/");
        }

        /// <inheritdoc/>
        public async Task<DataBundel<User>> SingUp(User user)
        {
            var request = await _requestService.CreateRequest("SingUp", "api/User");
            return await request.PostJsonAsync(user).ReceiveJson<DataBundel<User>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<User>> UpdateUser(User user)
        {
            var request = await _requestService.CreateRequest("UpdateUser", "api/User");
            return await request.PostJsonAsync(user).ReceiveJson<DataBundel<User>>();
        }

        /// <summary>
        /// Sets the credentials
        /// </summary>
        /// <param name="credentials"></param>
        private async Task SetCredentials(Credentials credentials)
        {
            await _localStorage.SetItemAsync("jwt", credentials.Jwt);
            await _localStorage.SetItemAsync("uid", credentials.Uid);
            await _localStorage.SetItemAsync("phh", credentials.Phh);
        }

        /// <inheritdoc/>
        public async Task SetUser()
        {
            var result = await GetUser();
            SessionUser.Data = result.Success ? result.Content : null;
        }

        /// <inheritdoc/>
        public async Task<DataBundel<List<UserFriend>>> AddFriends(List<UserFriend> friends)
        {
            var request = await _requestService.CreateRequest("AddFriends", "api/User");
            return await request.PostJsonAsync(friends).ReceiveJson<DataBundel<List<UserFriend>>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<string>> GeneratQR(string value)
        {
            var request = await _requestService.CreateRequest("GeneratQR", new Dictionary<string, string> { { "value", value } }, "api/User");
            return await request.GetJsonAsync<DataBundel<string>>();
        }

        #endregion

        #region Email

        /// <inheritdoc/>
        public async Task<DataBundel<Email>> SendPasswordResetTokenEmail(Email email)
        {
            var request = await _requestService.CreateRequest("SendPasswordResetTokenEmail", "api/User");
            return await request.PostJsonAsync(email).ReceiveJson<DataBundel<Email>>();
        }

        #endregion
    }
}
