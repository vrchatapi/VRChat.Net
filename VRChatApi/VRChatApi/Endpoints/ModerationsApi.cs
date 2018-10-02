using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class ModerationsApi
    {
        public async Task<List<PlayerModeratedResponse>> GetPlayerModerations()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderations");

            List<PlayerModeratedResponse> res = null;

            if (response.IsSuccessStatusCode)
            {
                res = JsonConvert.DeserializeObject<List<PlayerModeratedResponse>>(await response.Content.ReadAsStringAsync());
            }

            return res;
        }

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerated()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderated");

            List<PlayerModeratedResponse> res = null;

            if (response.IsSuccessStatusCode)
            {
                res = JsonConvert.DeserializeObject<List<PlayerModeratedResponse>>(await response.Content.ReadAsStringAsync());
            }

            return res;
        }
    }
}
