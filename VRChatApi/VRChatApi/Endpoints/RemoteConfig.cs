using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class RemoteConfig
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<ConfigResponse> Get()
        {
            Logger.Trace(() => "Getting remote config");
            HttpResponseMessage response = await Global.HttpClient.GetAsync("config");

            ConfigResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                res = JsonConvert.DeserializeObject<ConfigResponse>(json);
                Global.ApiKey = res.clientApiKey;
                Logger.Info(() => $"API key has been set to: {Global.ApiKey}");
            }

            return res;
        }
    }
}
