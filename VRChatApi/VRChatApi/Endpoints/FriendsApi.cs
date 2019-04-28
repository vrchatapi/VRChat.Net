using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VRChatApi.Classes;
using VRChatApi.Logging;

namespace VRChatApi.Endpoints
{
    public class FriendsApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<List<UserBriefResponse>> Get(int offset = 0, int count = 100, bool offline = false)
        {
            Logger.Debug(() => $"Getting friends with {nameof(offset)} = {offset}, {nameof(count)} = {count}, {nameof(offline)} = {offline}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user/friends?apiKey={Global.ApiKey}&offset={offset}&n={count}&offline={offline.ToString().ToLowerInvariant()}");

            List<UserBriefResponse> res = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                // try { res = JsonConvert.DeserializeObject<BanResponse>(json); } catch (System.Exception ex) { System.Console.WriteLine(ex.Message); }
                try { res = JsonConvert.DeserializeObject<List<UserBriefResponse>>(json); } catch (System.Exception ex) { System.Console.WriteLine(ex.Message); }
            }

            return res;
        }

        public async Task<NotificationResponse> SendRequest(string userId, string fromWho)
        {
            Logger.Debug(() => $"Sending friend request to {userId} from {fromWho}");
            JObject json = new JObject();
            json["type"] = "friendrequest";
            json["message"] = $"{fromWho} wants to be your friend";

            Logger.Debug(() => $"Prepared JSON to post: {json}");

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Global.HttpClient.PostAsync($"user/{userId}/notification?apiKey={Global.ApiKey}", content);
            

            NotificationResponse res = null;

            if (response.IsSuccessStatusCode)
            {
                var receivedJson = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {receivedJson}");
                res = JsonConvert.DeserializeObject<NotificationResponse>(receivedJson);
            }

            return res;
        }

        // TODO: proper return type, need to document
        public async Task<string> DeleteFriend(string userId)
        {
            HttpResponseMessage response = await Global.HttpClient.DeleteAsync($"auth/user/friends/{userId}?apiKey={Global.ApiKey}");

            string res = "";

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Logger.Debug(() => $"JSON received: {json}");
                res = json;
            }

            return res;
        }

        // TODO: proper return type, need to document
        public async Task AcceptFriend(string userId)
        {
            HttpResponseMessage response = await Global.HttpClient.PutAsync($"auth/user/notifications/{userId}/accept?apiKey={Global.ApiKey}", new StringContent(""));

            /*string res = "";

            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsStringAsync();
            }

            return res;*/
        }
    }
}
