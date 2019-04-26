using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class FavoritesAPI
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
        public async Task<List<FavoritesResponse>> Get(string type = null)
        {
            bool hasType = (type != null);
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"favorites?apiKey={Global.ApiKey}{(hasType ? $"&type={type}":"")}");
            List<FavoritesResponse> res = null;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");

                res = JsonConvert.DeserializeObject<List<FavoritesResponse>>(json);
            }

            return res;
        }
    }
}
