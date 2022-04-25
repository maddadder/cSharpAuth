using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace cSharpAuth.Services
{
    public class UserProfileService
    {
        private readonly HttpClient _httpClient;
        private readonly swaggerClient client;
        public UserProfileService(HttpClient httpClient){
            _httpClient = httpClient;
            client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
        }

        public async Task<IEnumerable<UserProfile>> GetUserProfileAsync(string email, string password, string search)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                return new List<UserProfile>();
            }
            UserLogin login = new UserLogin();
            login.Email = email;
            login.Password = password;
            try
            {
                var token = await client.AccountPostAsync(login);
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token.Token));
                return await client.UserProfileListAsync(search, null, null);
            }
            catch(Exception e)
            {
                return new List<UserProfile>();
            }
        }
    }
}
