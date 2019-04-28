using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;
using VRChatApi.Logging;
using System;

namespace VRChatApi.Endpoints
{
    public class NotificationsAPI
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
        public async Task<List<NotificationResponse>> GetAll(string type = "all", bool sent = false, DateTime? after = null)
        {
            var url = $"auth/user/notifications?apiKey={Global.ApiKey}&type={type}&sent={sent}";
            if (after != null) url += $"&after={after}";
            HttpResponseMessage response = await Global.HttpClient.GetAsync(url);
            List<NotificationResponse> res = null;
            if (response.IsSuccessStatusCode)
            {
                var receivedJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"JSON received: {receivedJson}");
                res = JsonConvert.DeserializeObject<List<NotificationResponse>>(receivedJson);
            }
            return res;
        }
    }
}
