using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lib;
using Microsoft.AspNetCore.Components.Authorization;

namespace cSharpAuth.Services
{
    public class BaseService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSecrets _appSecrets;
        private readonly swaggerClient client;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private List<UserToken> _tokenCache;
        public BaseService(
            List<UserToken> tokenCache,
            HttpClient httpClient, 
            AppSecrets appSecrets,
            AuthenticationStateProvider authenticationStateProvider
            )
        {
            _tokenCache = tokenCache;
            _authenticationStateProvider = authenticationStateProvider;
            _httpClient = httpClient;
            _appSecrets = appSecrets;
            client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
        }
        protected async Task<bool> AddAuthorizationHeader()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            string email = state.User?.Identity?.Name;
            if(string.IsNullOrEmpty(email)){
                return false;
            }
            var token = _tokenCache.Where(x => x.Email == email).FirstOrDefault();
            if(token != null && token.ExpiredTime > DateTime.UtcNow)
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token.Token));
                return true;
            }
            UserLogin login = new UserLogin();
            login.Email = email;
            login.Password = _appSecrets.UserProfilePassword;
            token = await client.AccountPostAsync(login);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token.Token));

            var existingToken = _tokenCache.Where(x => x.Email == email).FirstOrDefault();
            if(existingToken!=null){
                _tokenCache.Remove(existingToken);
                _tokenCache.Add(token);
            }
            else
            {
                _tokenCache.Add(token);
            }
            return true;
        }

    }
}
