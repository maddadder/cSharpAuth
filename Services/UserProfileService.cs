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

        public async Task<IEnumerable<UserProfile>> GetUserProfileAsync(string search)
        {
            return await client.UserProfileListAsync(search, null, null);
        }
    }
}
