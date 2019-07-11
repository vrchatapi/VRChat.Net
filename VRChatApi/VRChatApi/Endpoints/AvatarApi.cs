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
    public class AvatarApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<AvatarResponse> GetById(string id)
        {
            Logger.Debug(() => $"Getting avatar details using ID: {id}");
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/{id}?apiKey={Global.ApiKey}");

            AvatarResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");

                res = JsonConvert.DeserializeObject<AvatarResponse>(json);
            }

            return res;
        }

        public async Task<List<AvatarResponse>> Personal()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars?apiKey={Global.ApiKey}&releaseStatus=all&user=me&n=100");
            List<AvatarResponse> res = null;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");

                res = JsonConvert.DeserializeObject<List<AvatarResponse>>(json);
            }

            return res;
        }

        public async Task<List<AvatarResponse>> List()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars?apiKey={Global.ApiKey}");
            List<AvatarResponse> res = null;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");

                res = JsonConvert.DeserializeObject<List<AvatarResponse>>(json);
            }

            return res;
        }

        public async Task<List<AvatarResponse>> Favorites()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/favorites?apiKey={Global.ApiKey}&n=16");
            List<AvatarResponse> res = null;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");

                res = JsonConvert.DeserializeObject<List<AvatarResponse>>(json);
            }

            return res;
        }
    }
}
