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

        public async Task<IEnumerable<UserLink>> List(string search)
        {
            return await client.UserlinksAsync(search, null, null);
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
            await client.Userlink3Async(cmd);
        }
        public async Task Post(UserLinkOverride link)
        {
            UserLinkCreateRequestCommand cmd = new UserLinkCreateRequestCommand();
            cmd.Content = link.Content;
            cmd.Href = link.Href;
            cmd.Target = link.Target;
            await client.Userlink2Async(cmd);
        }
        public async Task Delete(Guid Pid)
        {
            await client.UserlinkAsync(Pid);
        }
    }
}
