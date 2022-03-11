using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace cSharpAuth.Data
{
    public class UserProfileService
    {
        private readonly HttpClient _httpClient;
        public UserProfileService(HttpClient httpClient){
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Profile>> GetUserProfileAsync(string search)
        {
            swaggerClient client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
            return await client.ProfilesAsync(search, null, null);
        }
        public async Task<IEnumerable<UserLink>> GetUserLinksAsync(string search)
        {
            swaggerClient client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
            return await client.UserlinksAsync(search, null, null);
        }
    }
}
