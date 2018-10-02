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
    public class ModerationsApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerations()
        {
            Logger.Trace(() => "Get list of moderations made by current user");
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderations");

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
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderated");

            List<PlayerModeratedResponse> res = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                res = JsonConvert.DeserializeObject<List<PlayerModeratedResponse>>(json);
            }

            return res;
        }
    }
}
