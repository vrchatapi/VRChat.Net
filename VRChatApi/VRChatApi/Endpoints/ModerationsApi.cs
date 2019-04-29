using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user/playermoderations?apiKey={Global.ApiKey}");

            List<PlayerModeratedResponse> res = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                res = JsonConvert.DeserializeObject<List<PlayerModeratedResponse>>(json);
            }

            return res;
        }

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerated()
        {
            Logger.Trace(() => "Get list of moderations made against current user");
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user/playermoderated?apiKey={Global.ApiKey}");

            List<PlayerModeratedResponse> res = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                res = JsonConvert.DeserializeObject<List<PlayerModeratedResponse>>(json);
            }

            return res;
        }


        public async Task<NotificationResponse> BlockUser(string userId)
        {
            JObject json = new JObject();
            json["blocked"] = userId;
            Logger.Debug(() => $"Prepared JSON to post: {json}");
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await Global.HttpClient.PostAsync($"auth/user/blocks?apiKey={Global.ApiKey}", content);
            NotificationResponse res = null;
            if (response.IsSuccessStatusCode)
            {
                var receivedJson = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {receivedJson}");
                res = JsonConvert.DeserializeObject<NotificationResponse>(receivedJson);
            }
            return res;
        }

        public async Task<string> UnblockUser(string userId, string modId)
        {
            HttpResponseMessage response = await Global.HttpClient.DeleteAsync($"user/{userId}/moderations/{modId}?apiKey={Global.ApiKey}");
            string res = "";
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                res = json;
            }
            return res;
        }

    }
}
