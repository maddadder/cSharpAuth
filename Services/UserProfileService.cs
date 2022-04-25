using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lib;

namespace cSharpAuth.Services
{
    public class UserProfileService
    {
        private readonly AppSecrets _appSecrets;
        private readonly HttpClient _httpClient;
        private readonly swaggerClient client;
        public UserProfileService(HttpClient httpClient, AppSecrets appSecrets){
            _httpClient = httpClient;
            _appSecrets = appSecrets;
            client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
        }

        public async Task<IEnumerable<UserProfile>> GetUserProfileAsync(string email, string search)
        {
            if(string.IsNullOrEmpty(email)){
                return new List<UserProfile>();
            }
            UserLogin login = new UserLogin();
            login.Email = email;
            login.Password = _appSecrets.UserProfilePassword;
            try
            {
                var token = await client.AccountPostAsync(login);
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token.Token));
                return await client.UserProfileListAsync(search, null, null);
            }
            catch
            {
                return new List<UserProfile>();
            }
        }
    }
}
