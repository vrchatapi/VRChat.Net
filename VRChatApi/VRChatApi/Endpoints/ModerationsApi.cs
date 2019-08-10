using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class ModerationsApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerations()
        {
            Logger.Trace(() => "Get list of moderations made by current user");

            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderations");

            return await Utils.ParseResponse<List<PlayerModeratedResponse>>(response);
        }

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerated()
        {
            Logger.Trace(() => "Get list of moderations made against current user");

            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderated");

            return await Utils.ParseResponse<List<PlayerModeratedResponse>>(response);
        }


        public async Task<NotificationResponse> BlockUser(string userId)
        {
            JObject json = new JObject() {
                { "blocked", userId }
            };
            Logger.Debug(() => $"Prepared JSON to post: {json}");
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await Global.HttpClient.PostAsync($"auth/user/blocks?apiKey={Global.ApiKey}", content);
            return await Utils.ParseResponse<NotificationResponse>(response);
        }

        public async Task<Response> UnblockUser(string userId)
        {
            JObject json = new JObject() {
                { "moderated", userId },
                { "type", "block" }
            };
            Logger.Debug(() => $"Prepared JSON to put: {json}");
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await Global.HttpClient.PutAsync($"auth/user/unplayermoderate?apiKey={Global.ApiKey}", content);
            return await Utils.ParseResponse<NotificationResponse>(response);
        }
    }
}
