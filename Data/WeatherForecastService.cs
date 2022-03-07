using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace cSharpAuth.Data
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;
        public WeatherForecastService(HttpClient httpClient){
            _httpClient = httpClient;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<Profile>> GetForecastAsync(string search)
        {
            swaggerClient client = new swaggerClient("https://couchclient.leenet.link",_httpClient);
            return await client.ProfilesAsync(search, null, null);
        }
    }
}
