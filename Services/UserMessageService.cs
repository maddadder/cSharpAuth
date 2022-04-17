using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lib;

namespace cSharpAuth.Services
{
    public class UserMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly swaggerClient client;
        public UserMessageService(HttpClient httpClient){
            _httpClient = httpClient;
            client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
        }

        public async Task<IEnumerable<UserMessage>> List(string search)
        {
            return await client.UserMessageListAsync(search, null, null);
        }
        public async Task<UserMessage> Get(string id)
        {
            Guid g = new Guid(id);
            return await client.UserMessageGetByIdAsync(g);
        }
        public async Task Put(UserMessage userMessage)
        {
            UserMessageUpdateRequestCommand cmd = new UserMessageUpdateRequestCommand();
            cmd.Body = userMessage.Body;
            cmd.To = userMessage.To;
            cmd.From = userMessage.From;
            cmd.ApiVersion = userMessage.ApiVersion;
            cmd.Pid = userMessage.Pid;
            await client.UserMessageUpdateAsync(cmd.Pid.ToString(), cmd);
        }
        
        public async Task Post(UserMessage userMessage)
        {
            UserMessageCreateRequestCommand cmd = new UserMessageCreateRequestCommand();
            cmd.Body = userMessage.Body;
            cmd.To = userMessage.To;
            cmd.From = userMessage.From;
            cmd.ApiVersion = userMessage.ApiVersion;
            await client.UserMesssagePostAsync(cmd);
        }
        public async Task Delete(Guid Pid)
        {
            await client.UserMessageDeleteAsync(Pid);
        }
    }
}
