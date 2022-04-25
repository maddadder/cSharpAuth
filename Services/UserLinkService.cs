using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lib;

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

        public async Task<IEnumerable<UserLink>> List(string search, int? limit, int? skip)
        {
            return await client.UserLinkListAsync(search, limit, skip);
        }
        public async Task<UserLink> Get(string id)
        {
            Guid g = new Guid(id);
            return await client.UserLinkGetByIdAsync(g);
        }
        public async Task Put(UserLinkOverride link)
        {
            UserLinkUpdateRequestCommand cmd = new UserLinkUpdateRequestCommand();
            cmd.Content = link.Content;
            cmd.Href = link.Href;
            cmd.Pid = link.Pid;
            cmd.Target = link.Target;
            await client.UserLinkUpdateAsync(cmd.Pid.ToString(), cmd);
        }
        public async Task Post(UserLinkOverride link)
        {
            UserLinkCreateRequestCommand cmd = new UserLinkCreateRequestCommand();
            cmd.Content = link.Content;
            cmd.Href = link.Href;
            cmd.Target = link.Target;
            await client.UserLinkPostAsync(cmd);
        }
        public async Task Delete(Guid Pid)
        {
            await client.UserLinkDeleteAsync(Pid);
        }
    }
}
