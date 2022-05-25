using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lib;
using Microsoft.AspNetCore.Components.Authorization;

namespace cSharpAuth.Services
{
    public class GameEntryService : BaseService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSecrets _appSecrets;
        private readonly swaggerClient client;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private List<UserToken> _tokenCache;
        public GameEntryService(
            List<UserToken> tokenCache,
            HttpClient httpClient, 
            AppSecrets appSecrets,
            AuthenticationStateProvider authenticationStateProvider
            ) : base(tokenCache, httpClient, appSecrets, authenticationStateProvider)
        {
            _tokenCache = tokenCache;
            _authenticationStateProvider = authenticationStateProvider;
            _httpClient = httpClient;
            _appSecrets = appSecrets;
            client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
        }
        public async Task<IEnumerable<GameEntry>> List(string search)
        {
            try
            {
                if(await AddAuthorizationHeader())
                    return await client.GameEntryListAsync(search, null, null);
                return new List<GameEntry>();
            }
            catch
            {
                return new List<GameEntry>();
            }
        }
        public async Task<GameEntry> Get(string id)
        {
            Guid g = new Guid(id);
            await AddAuthorizationHeader();
            return await client.GameEntryGetByIdAsync(g);
        }
        public async Task Put(GameEntry userMessage)
        {
            await AddAuthorizationHeader();
            GameEntryUpdateRequestCommand cmd = new GameEntryUpdateRequestCommand();
            cmd.Description = userMessage.Description;
            cmd.Name = userMessage.Name;
            cmd.Options = userMessage.Options;
            cmd.Pid = userMessage.Pid;
            await client.GameEntryUpdateAsync(cmd.Pid.ToString(), cmd);
        }
        
        public async Task Post(GameEntry userMessage)
        {
            await AddAuthorizationHeader();
            GameEntryCreateRequestCommand cmd = new GameEntryCreateRequestCommand();
            cmd.Description = userMessage.Description;
            cmd.Name = userMessage.Name;
            cmd.Options = userMessage.Options;
            await client.GameEntryPostAsync(cmd);
        }
        public async Task Delete(Guid Pid)
        {
            await AddAuthorizationHeader();
            await client.GameEntryDeleteAsync(Pid);
        }
    }
}