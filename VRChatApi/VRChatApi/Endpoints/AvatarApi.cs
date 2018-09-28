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
    public class AvatarApi
    {
        public async Task<AvatarResponse> GetById(string id)
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/{id}?apiKey={Global.ApiKey}");

            AvatarResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                res = JsonConvert.DeserializeObject<AvatarResponse>(await response.Content.ReadAsStringAsync());
            }

            return res;
        }
    }
}
