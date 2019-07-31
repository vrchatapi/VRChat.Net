using System.Net.Http;
using System.Threading.Tasks;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class AvatarApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<AvatarResponse> GetById(string id)
        {
            Logger.Debug(() => $"Getting avatar details using ID: {id}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/{id}?apiKey={Global.ApiKey}");

            return await Utils.ParseResponse<AvatarResponse>(response);
        }
    }
}
