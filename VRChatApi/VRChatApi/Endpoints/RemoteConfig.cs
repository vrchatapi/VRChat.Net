using System.Net.Http;
using System.Threading.Tasks;
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

            ConfigResponse res = await Utils.ParseResponse<ConfigResponse>(response);

            Global.ApiKey = res.clientApiKey;

            Logger.Info(() => $"API key has been set to: {res.clientApiKey}");

            return res;
        }
    }
}
