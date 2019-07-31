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
    public class FriendsApi
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<List<UserBriefResponse>> Get(int offset = 0, int count = 20, bool offline = false)
        {
            Logger.Debug(() => $"Getting friends with {nameof(offset)} = {offset}, {nameof(count)} = {count}, {nameof(offline)} = {offline}");

            HttpResponseMessage response = await Global.HttpClient.GetAsync($"auth/user/friends?apiKey={Global.ApiKey}&offset={offset}&n={count}&offline={offline.ToString().ToLowerInvariant()}");

            return await Utils.ParseResponse<List<UserBriefResponse>>(response);
        }

        public async Task<NotificationResponse> SendRequest(string userId, string fromWho)
        {
            Logger.Debug(() => $"Sending friend request to {userId} from {fromWho}");

            JObject json = new JObject()
            {
                { "type", "friendrequest" },
                { "message", $"{fromWho} wants to be your friend" }
            };

            Logger.Debug(() => $"Prepared JSON to post: {json}");

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Global.HttpClient.PostAsync($"user/{userId}/notification?apiKey={Global.ApiKey}", content);

            return await Utils.ParseResponse<NotificationResponse>(response);
        }

        public async Task<bool> DeleteFriend(string userId)
        {
            HttpResponseMessage response = await Global.HttpClient.DeleteAsync($"auth/user/friends/{userId}?apiKey={Global.ApiKey}");

            return Utils.ParseResponse<string>(response) != null;
        }

        public async Task<bool> AcceptFriend(string userId)
        {
            HttpResponseMessage response = await Global.HttpClient.PutAsync($"auth/user/notifications/{userId}/accept?apiKey={Global.ApiKey}", new StringContent(""));

            return Utils.ParseResponse<string>(response) != null;
        }
    }
}
