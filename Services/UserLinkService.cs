using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace cSharpAuth.Services
{
    public class UserLinkService
    {
        private readonly HttpClient _httpClient;
        private readonly swaggerClient client;
        public UserLinkService(HttpClient httpClient){
            _httpClient = httpClient;
            client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
        }

        public async Task<IEnumerable<UserLink>> GetUserLinksAsync(string search)
        {
            return await client.UserlinksAsync(search, null, null);
        }
    }
}
