using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class ModerationsApi
    {
        public async Task<List<PlayerModeratedResponse>> GetPlayerModerations()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderations");

            List<PlayerModeratedResponse> res = new List<PlayerModeratedResponse>();

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<List<PlayerModeratedResponse>>();
            }

            return res;
        }

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerated()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderated");

            List<PlayerModeratedResponse> res = new List<PlayerModeratedResponse>();

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<List<PlayerModeratedResponse>>();
            }

            return res;
        }
    }
}
