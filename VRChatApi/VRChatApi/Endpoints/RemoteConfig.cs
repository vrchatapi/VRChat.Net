using System.Net.Http;
using System.Threading.Tasks;
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
                res = await response.Content.ReadAsAsync<ConfigResponse>();
                Global.ApiKey = res.clientApiKey;
            }

            return res;
        }
    }
}
