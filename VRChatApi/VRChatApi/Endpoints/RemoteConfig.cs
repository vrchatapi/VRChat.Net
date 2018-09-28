using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class RemoteConfig
    {
        public async Task<ConfigResponse> Get()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("config");

            ConfigResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = JsonConvert.DeserializeObject<ConfigResponse>(await response.Content.ReadAsStringAsync());
                Global.ApiKey = res.clientApiKey;
            }

            return res;
        }
    }
}
